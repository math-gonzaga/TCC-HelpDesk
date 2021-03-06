using Dapper;
using HelpDesk.Domain.Interfaces.Repositories;
using HelpDesk.Domain.Interfaces.Repositories.DataConnector;
using HelpDesk.Domain.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IDbConnector _dbConnector;

        public UsuarioRepository(IDbConnector dbConnector)
        {
            this._dbConnector = dbConnector;
        }

        public async Task<Usuario> Get(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            var usuario = await _dbConnector.dbConnection.QueryAsync<Usuario>("GetUsuario", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return usuario.FirstOrDefault();
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@email", email);

            var usuario = await _dbConnector.dbConnection.QueryAsync<Usuario>("GetUsuarioByEmail", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return usuario.FirstOrDefault();
        }

        public async Task<Usuario> Registrar(Usuario usuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@nome", usuario.Nome);
            parameters.Add("@tipo", usuario.Tipo);
            parameters.Add("@descricao", usuario.Descricao);
            parameters.Add("@email", usuario.Email);
            parameters.Add("@senha", usuario.SenhaHash);

            var usuarioID = (int)await _dbConnector.dbConnection.ExecuteScalarAsync("RegistrarUsuario", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return await Get(usuarioID);
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", usuario.ID);
            parameters.Add("@nome", usuario.Nome);
            parameters.Add("@tipo", usuario.Tipo);
            parameters.Add("@descricao", usuario.Descricao);
            parameters.Add("@email", usuario.Email);

            await _dbConnector.dbConnection.ExecuteAsync("UpdateUsuario", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return await Get(usuario.ID);
        }
    }
}
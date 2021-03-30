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

        public async Task<Usuario> Registrar(Usuario usuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@nome", usuario.Nome);
            parameters.Add("@tipo", usuario.Tipo);
            parameters.Add("@descricao", usuario.Descricao);

            var usuarioID = await _dbConnector.dbConnection.ExecuteAsync("RegistrarUsuario", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return await Get(usuarioID);
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", usuario.ID);
            parameters.Add("@nome", usuario.Nome);
            parameters.Add("@tipo", usuario.Tipo);
            parameters.Add("@descricao", usuario.Descricao);

            await _dbConnector.dbConnection.ExecuteAsync("UpdateUsuario", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return usuario;
        }
    }
}
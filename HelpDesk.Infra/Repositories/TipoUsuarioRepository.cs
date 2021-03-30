using Dapper;
using HelpDesk.Domain.Interfaces.Repositories;
using HelpDesk.Domain.Interfaces.Repositories.DataConnector;
using HelpDesk.Domain.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Infra.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private IDbConnector _dbConnector;

        public TipoUsuarioRepository(IDbConnector dbConnector)
        {
            this._dbConnector = dbConnector;
        }

        public async Task<TipoUsuario> Get(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            var tipoUsuario = await _dbConnector.dbConnection.QueryAsync<TipoUsuario>("GetTipoUsuario", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return tipoUsuario.FirstOrDefault();
        }

        public async Task<List<TipoUsuario>> GetAll()
        {
            var tipoUsuarios = await _dbConnector.dbConnection.QueryAsync<TipoUsuario>("ListTipoUsuario", _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return tipoUsuarios.ToList();
        }
    }
}
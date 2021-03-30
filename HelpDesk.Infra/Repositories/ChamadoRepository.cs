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
    public class ChamadoRepository : IChamadoRepository
    {
        private IDbConnector _dbConnector;

        public ChamadoRepository(IDbConnector dbConnector)
        {
            this._dbConnector = dbConnector;
        }

        public async Task<Chamado> Get(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            var chamado = await _dbConnector.dbConnection.QueryAsync<Chamado>("GetChamado", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return chamado.FirstOrDefault();
        }

        public async Task<List<Chamado>> GetAll()
        {
            var chamados = await _dbConnector.dbConnection.QueryAsync<Chamado>("ListChamado", _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return chamados.ToList();
        }

        public async Task<Chamado> Registrar(Chamado chamado)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@nome", chamado.Nome);
            parameters.Add("@idUsuario", chamado.Usuario.ID);
            parameters.Add("@idUsuarioResposta", chamado.UsuarioResposta.ID);
            parameters.Add("@mensagens", chamado.Mensagens);

            var chamadoID = await _dbConnector.dbConnection.ExecuteAsync("RegistrarChamado", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return await Get(chamadoID);
        }

        public async Task<Chamado> Update(Chamado chamado)
        {
            DataTable MensagemChamadosList = CreateMensagensListParameter(chamado.Mensagens);

            var parameters = new DynamicParameters();
            parameters.Add("@nome", chamado.Nome);
            parameters.Add("@idUsuario", chamado.Usuario.ID);
            parameters.Add("@idUsuarioResposta", chamado.UsuarioResposta.ID);
            parameters.Add("@mensagens", GetTableValueParameter(MensagemChamadosList, "dbo.MensagemChamadoListTableType"));

            await _dbConnector.dbConnection.QueryAsync("UpdateChamado", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            return chamado;
        }

        private DataTable CreateMensagensListParameter(List<MensagemChamado> mensagemChamados)
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("Mensagem", typeof(string));
            tb.Columns.Add("UsuarioId", typeof(int));
            tb.Columns.Add("DataCriacao", typeof(DataSetDateTime));

            foreach (var x in mensagemChamados)
            {
                tb.Rows.Add(x);
            }

            return tb;
        }

        public static Dapper.SqlMapper.ICustomQueryParameter GetTableValueParameter(DataTable dt, string type)
        {
            return dt.AsTableValuedParameter(type);
        }
    }
}
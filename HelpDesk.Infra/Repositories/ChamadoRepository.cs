using Dapper;
using HelpDesk.Domain.Interfaces.Repositories;
using HelpDesk.Domain.Interfaces.Repositories.DataConnector;
using HelpDesk.Domain.Models;
using System;
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

            var multi = await _dbConnector.dbConnection.QueryMultipleAsync("GetChamado", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            var chamado = multi.Read<Chamado>().FirstOrDefault();
            var mensagems = multi.Read<MensagemChamado>().ToList();

            if (chamado != null)
                chamado.Mensagens = mensagems;

            return chamado;
        }

        public async Task<List<Chamado>> GetAll()
        {
            var multi = await _dbConnector.dbConnection.QueryMultipleAsync("ListChamado", _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            var chamados = multi.Read<Chamado>().ToList();
            var mensagens = multi.Read<MensagemChamado>().ToList();

            foreach (var chamado in chamados)
            {
                chamado.Mensagens = mensagens.Where((x) => x.ChamadoID == chamado.ID).ToList();
            }

            return chamados;
        }

        public async Task<Chamado> Registrar(Chamado chamado)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@nome", chamado.Nome);
            parameters.Add("@idUsuario", chamado.UsuarioID);
            parameters.Add("@idUsuarioResposta", chamado.UsuarioRespostaID);

            var chamadoID = (int)await _dbConnector.dbConnection.ExecuteScalarAsync("RegistrarChamado", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            foreach (var item in chamado.Mensagens)
            {
                MensagemSave(item, chamadoID);
            }

            return await Get(chamadoID);
        }

        public async Task<Chamado> Update(Chamado chamado)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", chamado.ID);
            parameters.Add("@nome", chamado.Nome);
            parameters.Add("@idUsuario", chamado.UsuarioID);
            parameters.Add("@idUsuarioResposta", chamado.UsuarioRespostaID);

            await _dbConnector.dbConnection.QueryAsync("UpdateChamado", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);

            foreach (var item in chamado.Mensagens)
            {
                MensagemSave(item, chamado.ID);
            }

            return await Get(chamado.ID);
        }


        public void MensagemSave(MensagemChamado mensagem, int chamadoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", mensagem.ID);
            parameters.Add("@chamadoId", chamadoId);
            parameters.Add("@idUsuario", mensagem.UsuarioID);
            parameters.Add("@mensagem", mensagem.Mensagem);

            _dbConnector.dbConnection.Execute("RegistrarMensagem", parameters, _dbConnector.dbTransaction, commandType: CommandType.StoredProcedure);
        }
    }
}
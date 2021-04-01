using HelpDesk.Domain.Models;
using System;
using System.Collections.Generic;

namespace HelpDesk.Application.DataContract.Response.Chamado
{
    public class ChamadoResponse
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int UsuarioID { get; set; }
        public int UsuarioRespostaID { get; set; }
        public List<MensagemChamado> Mensagens { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
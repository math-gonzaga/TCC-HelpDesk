using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Models
{
    public class Chamado : EntityBase
    {
        public string Nome { get; set; }
        public int UsuarioID { get; set; }
        public int UsuarioRespostaID { get; set; }
        public List<MensagemChamado> Mensagens { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
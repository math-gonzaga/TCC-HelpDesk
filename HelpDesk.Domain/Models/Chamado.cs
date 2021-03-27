using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Models
{
    public class Chamado
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
        public Usuario usuarioResposta { get; set; }
        public List<MensagemChamado> Mensagens { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
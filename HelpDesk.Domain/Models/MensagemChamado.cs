using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Domain.Models
{
    public class MensagemChamado
    {
        public int ID { get; set; }
        public string Mensagem { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}

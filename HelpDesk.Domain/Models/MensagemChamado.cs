using System;

namespace HelpDesk.Domain.Models
{
    public class MensagemChamado
    {
        public int ID { get; set; }
        public string Mensagem { get; set; }
        public int Usuario { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
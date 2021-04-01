using System;

namespace HelpDesk.Domain.Models
{
    public class MensagemChamado : EntityBase
    {
        public int ChamadoID { get; set; }
        public string Mensagem { get; set; }
        public int UsuarioID { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
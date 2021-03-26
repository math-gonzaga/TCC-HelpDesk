using HelpDesk.Domain.Models.Enums;

namespace HelpDesk.Domain.Models
{
    public class TipoUsuario
    {
        public int ID { get; set; }
        public TipoUsuarionEnum Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
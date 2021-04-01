using HelpDesk.Domain.Models.Enums;

namespace HelpDesk.Application.DataContract.Request.Usuario
{
    public class UpdateUsuarioRequest
    {
        public int ID { get; set; }
        public TipoUsuarionEnum Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
    }
}
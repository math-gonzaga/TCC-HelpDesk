using HelpDesk.Domain.Models.Enums;

namespace HelpDesk.Application.DataContract.Response.TipoUsuario
{
    public class TipoUsuarioResponse
    {
        public int ID { get; set; }
        public TipoUsuarionEnum Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
using HelpDesk.Domain.Models.Enums;

namespace HelpDesk.Application.DataContract.Request.Usuario
{
    public class RegistrarUsuarioRequest
    {
        public TipoUsuarionEnum Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}
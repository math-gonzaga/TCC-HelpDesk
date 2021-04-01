using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations.Base;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Response<bool>> AutenticarUsuario(string senha, Usuario usuario);

        Task<Response<Usuario>> Get(int id);

        Task<Response> Registrar(Usuario usuario);

        Task<Response> Update(Usuario usuario);
        Task<Response<Usuario>> GetByEmail(string email);
    }
}
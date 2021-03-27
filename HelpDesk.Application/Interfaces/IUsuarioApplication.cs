using HelpDesk.Application.DataContract.Request.Usuario;
using HelpDesk.Domain.Validations.Base;
using System.Threading.Tasks;

namespace HelpDesk.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<Response> Get(int id);

        Task<Response> Registrar(RegistrarUsuarioRequest usuarioRequest);

        Task<Response> Update(UpdateUsuarioRequest usuarioRequest);
    }
}
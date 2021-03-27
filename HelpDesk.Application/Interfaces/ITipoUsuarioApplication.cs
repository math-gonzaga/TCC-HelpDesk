using HelpDesk.Domain.Validations.Base;
using System.Threading.Tasks;

namespace HelpDesk.Application.Interfaces
{
    public interface ITipoUsuarioApplication
    {
        Task<Response> Get(int id);

        Task<Response> GetAll();
    }
}
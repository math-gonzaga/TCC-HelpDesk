using HelpDesk.Application.DataContract.Request.Chamado;
using HelpDesk.Domain.Validations.Base;
using System.Threading.Tasks;

namespace HelpDesk.Application.Interfaces
{
    public interface IChamadoApplication
    {
        Task<Response> Get(int id);

        Task<Response> GetAll();

        Task<Response> Registar(RegistrarChamadoRequest registrarChamado);

        Task<Response> Update(UpdateChamadoRequest updateChamado);
    }
}
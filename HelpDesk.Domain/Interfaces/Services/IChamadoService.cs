using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Interfaces.Services
{
    public interface IChamadoService
    {
        Task<Response> Get(int id);

        Task<Response> GetAll();

        Task<Response> Registrar(Chamado chamado);

        Task<Response> Update(Chamado chamado);
    }
}
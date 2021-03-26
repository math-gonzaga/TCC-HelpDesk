using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Interfaces.Services
{
    public interface ITipoUsuarioService
    {
        Task<Response> Get(int id);

        Task<Response> GetAll();
    }
}
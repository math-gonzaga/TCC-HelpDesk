using HelpDesk.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Interfaces.Repositories
{
    public interface ITipoUsuarioRepository
    {
        Task<TipoUsuario> Get(int id);

        Task<List<TipoUsuario>> GetAll();
    }
}
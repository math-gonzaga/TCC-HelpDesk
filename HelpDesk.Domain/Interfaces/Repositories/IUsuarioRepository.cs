using HelpDesk.Domain.Models;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Get(int id);

        Task<Usuario> Registrar(Usuario usuario);

        Task<Usuario> Update(Usuario usuario);
    }
}
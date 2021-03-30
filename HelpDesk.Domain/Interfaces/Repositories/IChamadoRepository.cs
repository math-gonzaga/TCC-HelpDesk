using HelpDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Interfaces.Repositories
{
    public interface IChamadoRepository
    {
        Task<Chamado> Get(int id);

        Task<List<Chamado>> GetAll();

        Task<Chamado> Registrar(Chamado chamado);

        Task<Chamado> Update(Chamado chamado);
    }
}

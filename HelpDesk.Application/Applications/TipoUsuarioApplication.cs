using AutoMapper;
using HelpDesk.Application.Interfaces;
using HelpDesk.Domain.Interfaces.Services;
using HelpDesk.Domain.Validations.Base;
using System.Threading.Tasks;

namespace HelpDesk.Application.Applications
{
    public class TipoUsuarioApplication : ITipoUsuarioApplication
    {
        private readonly ITipoUsuarioService _tipoUsuarioService;
        private readonly IMapper _mapper;

        public TipoUsuarioApplication(ITipoUsuarioService tipoUsuarioService, IMapper mapper)
        {
            this._tipoUsuarioService = tipoUsuarioService;
            this._mapper = mapper;
        }

        public async Task<Response> Get(int id)
        {
            return await _tipoUsuarioService.Get(id);
        }

        public async Task<Response> GetAll()
        {
            return await _tipoUsuarioService.GetAll();
        }
    }
}
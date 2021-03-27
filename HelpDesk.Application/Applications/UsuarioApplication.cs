using AutoMapper;
using HelpDesk.Application.DataContract.Request.Usuario;
using HelpDesk.Application.Interfaces;
using HelpDesk.Domain.Interfaces.Services;
using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations.Base;
using System.Threading.Tasks;

namespace HelpDesk.Application.Applications
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioApplication(IUsuarioService usuarioService, IMapper mapper)
        {
            this._usuarioService = usuarioService;
            this._mapper = mapper;
        }

        public async Task<Response> Get(int id)
        {
            return await _usuarioService.Get(id);
        }

        public async Task<Response> Registrar(RegistrarUsuarioRequest usuarioRequest)
        {
            var usuario = _mapper.Map<Usuario>(usuarioRequest);

            return await _usuarioService.Registrar(usuario);
        }

        public async Task<Response> Update(UpdateUsuarioRequest usuarioRequest)
        {
            var usuario = _mapper.Map<Usuario>(usuarioRequest);

            return await _usuarioService.Update(usuario);
        }
    }
}
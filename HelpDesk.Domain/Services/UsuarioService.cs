using HelpDesk.Domain.Interfaces.Repositories;
using HelpDesk.Domain.Interfaces.Services;
using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations;
using HelpDesk.Domain.Validations.Base;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public async Task<Response> Get(int id)
        {
            var response = new Response<Usuario>();

            var data = await _usuarioRepository.Get(id);
            response.Data = data;

            return response;
        }

        public async Task<Response> Registrar(Usuario usuario)
        {
            var response = new Response<Usuario>();
            var validation = new UsuarioValidation();
            var erros = validation.Validate(usuario).GetErros();

            if (erros.Report.Count > 0)
                return erros;

            var data = await _usuarioRepository.Registrar(usuario);
            response.Data = data;

            return response;
        }

        public async Task<Response> Update(Usuario usuario)
        {
            var response = new Response<Usuario>();
            var validation = new UsuarioValidation();
            var erros = validation.Validate(usuario).GetErros();

            if (erros.Report.Count > 0)
                return erros;

            var data = await _usuarioRepository.Update(usuario);
            response.Data = data;

            return response;
        }
    }
}
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
        private readonly ISegurancaService _segurancaService;

        public UsuarioService(IUsuarioRepository usuarioRepository, ISegurancaService segurancaService)
        {
            this._usuarioRepository = usuarioRepository;
            this._segurancaService = segurancaService;
        }

        public async Task<Response<bool>> AutenticarUsuario(string senha, Usuario usuario)
        {
            return await _segurancaService.VerificarSenha(senha, usuario);
        }

        public async Task<Response<Usuario>> Get(int id)
        {
            var response = new Response<Usuario>();

            var data = await _usuarioRepository.Get(id);
            response.Data = data;

            return response;
        }

        public async Task<Response<Usuario>> GetByEmail(string email)
        {
            var response = new Response<Usuario>();

            var data = await _usuarioRepository.GetByEmail(email);
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
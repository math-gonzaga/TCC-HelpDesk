using HelpDesk.Domain.Interfaces.Repositories;
using HelpDesk.Domain.Interfaces.Services;
using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioService(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            this._tipoUsuarioRepository = tipoUsuarioRepository;
        }

        public async Task<Response> Get(int id)
        {
            var response = new Response<TipoUsuario>();

            var data = await _tipoUsuarioRepository.Get(id);
            response.Data = data;

            return response;
        }

        public async Task<Response> GetAll()
        {
            var response = new Response<List<TipoUsuario>>();

            var data = await _tipoUsuarioRepository.GetAll();
            response.Data = data;

            return response;
        }
    }
}
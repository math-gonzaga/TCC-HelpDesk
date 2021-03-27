using AutoMapper;
using HelpDesk.Application.DataContract.Request.Chamado;
using HelpDesk.Application.Interfaces;
using HelpDesk.Domain.Interfaces.Services;
using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations.Base;
using System.Threading.Tasks;

namespace HelpDesk.Application.Applications
{
    public class ChamadoApplication : IChamadoApplication
    {
        private readonly IChamadoService _chamadoService;
        private readonly IMapper _mapper;

        public ChamadoApplication(IChamadoService chamadoService, IMapper mapper)
        {
            this._chamadoService = chamadoService;
            this._mapper = mapper;
        }

        public async Task<Response> Get(int id)
        {
            return await _chamadoService.Get(id);
        }

        public async Task<Response> GetAll()
        {
            return await _chamadoService.GetAll();
        }

        public async Task<Response> Registar(RegistrarChamadoRequest registrarChamado)
        {
            var chamado = _mapper.Map<Chamado>(registrarChamado);

            return await _chamadoService.Registar(chamado);
        }

        public async Task<Response> Update(UpdateChamadoRequest updateChamado)
        {
            var chamado = _mapper.Map<Chamado>(updateChamado);

            return await _chamadoService.Update(chamado);
        }
    }
}
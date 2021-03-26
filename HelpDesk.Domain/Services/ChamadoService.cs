using HelpDesk.Domain.Interfaces.Repositories;
using HelpDesk.Domain.Interfaces.Services;
using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations;
using HelpDesk.Domain.Validations.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Services
{
    public class ChamadoService : IChamadoService
    {
        private readonly IChamadoRepository _chamadoRepository;

        public ChamadoService(IChamadoRepository chamadoRepository)
        {
            this._chamadoRepository = chamadoRepository;
        }

        public async Task<Response> Get(int id)
        {
            var response = new Response<Chamado>();

            var data = await _chamadoRepository.Get(id);
            response.Data = data;

            return response;
        }

        public async Task<Response> GetAll()
        {
            var response = new Response<List<Chamado>>();

            var data = await _chamadoRepository.GetAll();
            response.Data = data;

            return response;
        }

        public async Task<Response> Registar(Chamado chamado)
        {
            var response = new Response<Chamado>();
            var validation = new ChamadoValidation();
            var erros = validation.Validate(chamado).GetErros();

            if (erros.Report.Count > 0)
                return erros;

            var data = await _chamadoRepository.Registar(chamado);
            response.Data = data;

            return response;
        }

        public async Task<Response> Update(Chamado chamado)
        {
            var response = new Response<Chamado>();
            var validation = new ChamadoValidation();
            var erros = validation.Validate(chamado).GetErros();

            if (erros.Report.Count > 0)
                return erros;

            var data = await _chamadoRepository.Update(chamado);
            response.Data = data;

            return response;
        }
    }
}
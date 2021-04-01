using AutoMapper;
using HelpDesk.Application.DataContract.Request.Chamado;
using HelpDesk.Application.Interfaces;
using HelpDesk.Domain.Interfaces.Services;
using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations.Base;
using System;
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
            try
            {
                return await _chamadoService.Get(id);
            }
            catch (Exception ex)
            {
                var response = Report.Create(ex.Message);

                return Response.Unprocessable(response);
            }
        }

        public async Task<Response> GetAll()
        {
            try
            {
                return await _chamadoService.GetAll();
            }
            catch (Exception ex)
            {
                var response = Report.Create(ex.Message);

                return Response.Unprocessable(response);
            }
        }

        public async Task<Response> Registrar(RegistrarChamadoRequest registrarChamado)
        {
            try
            {
                var chamado = _mapper.Map<Chamado>(registrarChamado);

                return await _chamadoService.Registrar(chamado);
            }
            catch (Exception ex)
            {
                var response = Report.Create(ex.Message);

                return Response.Unprocessable(response);
            }
        }

        public async Task<Response> Update(UpdateChamadoRequest updateChamado)
        {
            try
            {
                var chamado = _mapper.Map<Chamado>(updateChamado);

                return await _chamadoService.Update(chamado);
            }
            catch (Exception ex)
            {
                var response = Report.Create(ex.Message);

                return Response.Unprocessable(response);
            }
        }
    }
}
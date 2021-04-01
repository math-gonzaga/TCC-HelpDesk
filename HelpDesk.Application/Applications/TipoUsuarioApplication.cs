using AutoMapper;
using HelpDesk.Application.Interfaces;
using HelpDesk.Domain.Interfaces.Services;
using HelpDesk.Domain.Validations.Base;
using System;
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
            try
            {
                return await _tipoUsuarioService.Get(id);
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
                return await _tipoUsuarioService.GetAll();
            }
            catch (Exception ex)
            {
                var response = Report.Create(ex.Message);

                return Response.Unprocessable(response);
            }
        }
    }
}
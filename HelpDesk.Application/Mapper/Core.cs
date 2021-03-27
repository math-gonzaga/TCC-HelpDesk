using AutoMapper;
using HelpDesk.Application.DataContract.Request.Chamado;
using HelpDesk.Application.DataContract.Request.Usuario;
using HelpDesk.Domain.Models;

namespace HelpDesk.Application.Mapper
{
    public class Core : Profile
    {
        public Core()
        {
            UsuarioMap();
            ChamadoMap();
        }

        private void UsuarioMap()
        {
            CreateMap<RegistrarUsuarioRequest, Usuario>();
            CreateMap<UpdateUsuarioRequest, Usuario>();
        }

        private void ChamadoMap()
        {
            CreateMap<RegistrarChamadoRequest, Chamado>();
            CreateMap<UpdateChamadoRequest, Chamado>();
        }
    }
}
using AutoMapper;
using HelpDesk.Application.DataContract.Request.Chamado;
using HelpDesk.Application.DataContract.Request.Usuario;
using HelpDesk.Application.DataContract.Response.Chamado;
using HelpDesk.Application.DataContract.Response.TipoUsuario;
using HelpDesk.Application.DataContract.Response.Usuario;
using HelpDesk.Domain.Models;

namespace HelpDesk.Application.Mapper
{
    public class Core : Profile
    {
        public Core()
        {
            UsuarioMap();
        }

        private void UsuarioMap()
        {
            CreateMap<RegistrarUsuarioRequest, Usuario>()
                .ForMember(target => target.SenhaHash, opt => opt.MapFrom(source => source.Senha));

            CreateMap<UpdateUsuarioRequest, Usuario>();

            CreateMap<Usuario, UsuarioResponse>();

            CreateMap<RegistrarChamadoRequest, Chamado>();
            CreateMap<UpdateChamadoRequest, Chamado>();

            CreateMap<Chamado, ChamadoResponse>();

            CreateMap<TipoUsuario, TipoUsuarioResponse>();

        }
    }
}
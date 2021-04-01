using AutoMapper;
using HelpDesk.Application.DataContract.Request.Usuario;
using HelpDesk.Application.DataContract.Response.Usuario;
using HelpDesk.Application.Interfaces;
using HelpDesk.Application.Interfaces.Security;
using HelpDesk.Domain.Interfaces.Services;
using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Application.Applications
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly ISegurancaService _segurancaService;
        private readonly ITokenManager _tokenManager;

        public UsuarioApplication(IUsuarioService usuarioService, IMapper mapper, ISegurancaService segurancaService, ITokenManager tokenManager)
        {
            this._usuarioService = usuarioService;
            this._mapper = mapper;
            this._segurancaService = segurancaService;
            this._tokenManager = tokenManager;
        }

        public async Task<Response<AutenticarResponse>> AutenticarUsuario(AutenticarRequest autenticarRequest)
        {
            var usuario = await _usuarioService.GetByEmail(autenticarRequest.Email);

            if (usuario.Report.Any())
                return Response.Unprocessable<AutenticarResponse>(usuario.Report);

            var autenticado = await _usuarioService.AutenticarUsuario(autenticarRequest.Senha, usuario.Data);

            if (!autenticado.Data)
                return Response.Unprocessable<AutenticarResponse>(new List<Report>() { Report.Create("Senah ou Email incorretos") });

            var token = await _tokenManager.GenerateToken(usuario.Data);

            return new Response<AutenticarResponse>(token);
        }

        public async Task<Response> Get(int id)
        {
            try
            {
                return await _usuarioService.Get(id);
            }
            catch (Exception ex)
            {
                var response = Report.Create(ex.Message);

                return Response.Unprocessable(response);
            }
        }

        public async Task<Response> Registrar(RegistrarUsuarioRequest usuarioRequest)
        {
            try
            {
                var equals = await _segurancaService.CompararSenha(usuarioRequest.Senha, usuarioRequest.ConfirmacaoSenha);

                if (!equals.Data)
                    return Response.Unprocessable(Report.Create("Senhas não são iguais"));

                var senhaEncrypted = await _segurancaService.EncryptSenha(usuarioRequest.Senha);
                usuarioRequest.Senha = senhaEncrypted.Data;

                var usuario = _mapper.Map<Usuario>(usuarioRequest);

                return await _usuarioService.Registrar(usuario);
            }
            catch (Exception ex)
            {
                var response = Report.Create(ex.Message);

                return Response.Unprocessable(response);
            }
        }

        public async Task<Response> Update(UpdateUsuarioRequest usuarioRequest)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioRequest);

                return await _usuarioService.Update(usuario);
            }
            catch (Exception ex)
            {
                var response = Report.Create(ex.Message);

                return Response.Unprocessable(response);
            }
        }
    }
}
using HelpDesk.Domain.Interfaces.Services;
using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations.Base;
using System;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Services
{
    public class SegurancaService : ISegurancaService
    {
        public Task<Response<bool>> CompararSenha(string senha, string confirmaSenha)
        {
            var equals = senha.Trim().Equals(confirmaSenha.Trim());
            return Task.FromResult(Response.Ok<bool>(equals));
        }

        public Task<Response<string>> EncryptSenha(string senha)
        {
            var senhaEncrypt = BCrypt.Net.BCrypt.HashPassword(senha);
            return Task.FromResult(Response.Ok<string>(senhaEncrypt));
        }

        public Task<Response<bool>> VerificarSenha(string senha, Usuario usuario)
        {
            bool validarSenha = BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash);
            return Task.FromResult(Response.Ok<bool>(validarSenha));
        }
    }
}
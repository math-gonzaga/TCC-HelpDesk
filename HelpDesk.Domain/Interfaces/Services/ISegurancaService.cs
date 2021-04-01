using HelpDesk.Domain.Models;
using HelpDesk.Domain.Validations.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Interfaces.Services
{
    public interface ISegurancaService
    {
        Task<Response<bool>> CompararSenha(string senha, string confirmaSenha);
        Task<Response<bool>> VerificarSenha(string senha, Usuario usuario);
        Task<Response<string>> EncryptSenha(string senha);
    }
}

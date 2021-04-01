using HelpDesk.Application.DataContract.Response.Usuario;
using HelpDesk.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Application.Interfaces.Security
{
    public interface ITokenManager
    {
        Task<AutenticarResponse> GenerateToken(Usuario usuario);
    }
}

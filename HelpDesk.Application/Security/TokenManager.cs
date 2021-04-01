using HelpDesk.Application.DataContract.Response.Usuario;
using HelpDesk.Application.Interfaces.Security;
using HelpDesk.Application.Models;
using HelpDesk.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Application.Security
{
    public class TokenManager : ITokenManager
    {
        private readonly AuthSettings _authSettings;

        public TokenManager(IOptions<AuthSettings> authSettings)
        {
            this._authSettings = authSettings.Value;
        }

        public Task<AutenticarResponse> GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.ID.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(_authSettings.ExpireIn),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var response = new AutenticarResponse()
            {
                Token = tokenHandler.WriteToken(token),
                ExpiraEm = _authSettings.ExpireIn,
                Type = JwtBearerDefaults.AuthenticationScheme
            };

            return Task.FromResult(response);
        }
    }
}
using HelpDesk.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HelpDesk.API.Controllers
{
    [Route("api/tipousuario")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioApplication _tipoUsuarioApplication;

        public TipoUsuarioController(ITipoUsuarioApplication tipoUsuarioApplication)
        {
            this._tipoUsuarioApplication = tipoUsuarioApplication;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _tipoUsuarioApplication.GetAll();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var response = await _tipoUsuarioApplication.Get(id);

            return Ok(response);
        }
    }
}
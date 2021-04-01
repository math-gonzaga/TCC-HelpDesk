using HelpDesk.Application.DataContract.Request.Chamado;
using HelpDesk.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.API.Controllers
{
    [Route("api/chamado")]
    [ApiController]
    [Authorize]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoApplication _chamadoApplication;

        public ChamadoController(IChamadoApplication chamadoApplication)
        {
            this._chamadoApplication = chamadoApplication;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _chamadoApplication.GetAll();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var response = await _chamadoApplication.Get(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RegistrarChamadoRequest request)
        {
            var response = await _chamadoApplication.Registrar(request);

            if (response.Report.Any())
                return UnprocessableEntity(response.Report);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateChamadoRequest request)
        {
            request.ID = id;
            var response = await _chamadoApplication.Update(request);

            if (response.Report.Any())
                return UnprocessableEntity(response.Report);

            return Ok(response);
        }
    }
}
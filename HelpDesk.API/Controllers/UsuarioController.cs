﻿using HelpDesk.Application.DataContract.Request.Usuario;
using HelpDesk.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            this._usuarioApplication = usuarioApplication;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RegistrarUsuarioRequest request)
        {
            var response = await _usuarioApplication.Registrar(request);

            if (response.Report.Any())
                return UnprocessableEntity(response.Report);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateUsuarioRequest request)
        {
            request.ID = id;
            var response = await _usuarioApplication.Update(request);

            if (response.Report.Any())
                return UnprocessableEntity(response.Report);

            return Ok(response);
        }
    }
}
using HelpDesk.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.DataContract.Response.Usuario
{
    public class UsuarioResponse
    {
        public int ID { get; set; }
        public TipoUsuarionEnum Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

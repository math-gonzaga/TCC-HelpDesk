using HelpDesk.Domain.Models.Enums;
using System;

namespace HelpDesk.Application.DataContract.Response.Usuario
{
    public class UsuarioResponse
    {
        public int ID { get; set; }
        public TipoUsuarionEnum Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
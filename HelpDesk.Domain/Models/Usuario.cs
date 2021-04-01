using HelpDesk.Domain.Models.Enums;
using System;

namespace HelpDesk.Domain.Models
{
    public class Usuario : EntityBase
    {
        public TipoUsuarionEnum Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
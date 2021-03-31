using HelpDesk.Domain.Models.Enums;
using System;

namespace HelpDesk.Domain.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public TipoUsuarionEnum Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
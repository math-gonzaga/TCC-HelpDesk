using System;

namespace HelpDesk.Domain.Models
{
    public class Chamado
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public int ChamadoParente { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
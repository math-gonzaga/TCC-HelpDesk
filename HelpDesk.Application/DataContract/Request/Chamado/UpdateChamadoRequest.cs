using HelpDesk.Domain.Models;
using System;
using System.Collections.Generic;

namespace HelpDesk.Application.DataContract.Request.Chamado
{
    public class UpdateChamadoRequest
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        //TODO: Verificar por que não pode colocar o objeto usuario
        public int Usuario { get; set; }

        public int UsuarioResposta { get; set; }
        public List<MensagemChamado> Mensagens { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
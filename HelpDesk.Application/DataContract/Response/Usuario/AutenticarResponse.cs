using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.DataContract.Response.Usuario
{
    public sealed class AutenticarResponse
    {
        public string Token { get; set; }
        public string Type { get; set; }
        public int ExpiraEm { get; set; }
    }
}

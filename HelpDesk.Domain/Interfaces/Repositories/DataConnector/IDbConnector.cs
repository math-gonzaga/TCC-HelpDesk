using System;
using System.Data;

namespace HelpDesk.Domain.Interfaces.Repositories.DataConnector
{
    public interface IDbConnector : IDisposable
    {
        public IDbConnection dbConnection { get; }
        public IDbTransaction dbTransaction { get; set; }
    }
}
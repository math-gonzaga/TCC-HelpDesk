using HelpDesk.Domain.Interfaces.Repositories.DataConnector;
using System.Data;
using System.Data.OracleClient;

namespace HelpDesk.Infra.DataConnector
{
    public class OracleConnector : IDbConnector
    {
        public OracleConnector(string connectionString)
        {
            dbConnection = OracleClientFactory.Instance.CreateConnection();
            dbConnection.ConnectionString = connectionString;
        }
        public IDbConnection dbConnection { get; }

        public IDbTransaction dbTransaction { get; set; }

        public void Dispose()
        {
            dbConnection?.Dispose();
            dbTransaction?.Dispose();
        }
    }
}
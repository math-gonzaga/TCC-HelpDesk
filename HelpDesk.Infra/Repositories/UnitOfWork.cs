using HelpDesk.Domain.Interfaces.Repositories;
using HelpDesk.Domain.Interfaces.Repositories.DataConnector;
using System.Data;

namespace HelpDesk.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUsuarioRepository _usuarioRepository;
        private IChamadoRepository _chamadoRepository;
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public UnitOfWork(IDbConnector dbConnector)
        {
            this.dbConnector = dbConnector;
        }

        public IUsuarioRepository usuarioRepository => _usuarioRepository ?? (_usuarioRepository = new UsuarioRepository(dbConnector));

        public IChamadoRepository chamadoRepository => _chamadoRepository ?? (_chamadoRepository = new ChamadoRepository(dbConnector));

        public ITipoUsuarioRepository tipoUsuarioRepository => _tipoUsuarioRepository ?? (_tipoUsuarioRepository = new TipoUsuarioRepository(dbConnector));

        public IDbConnector dbConnector { get; }

        public void BeginTransaction()
        {
            if (dbConnector.dbConnection.State == System.Data.ConnectionState.Open)
            {
                dbConnector.dbTransaction = dbConnector.dbConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
            }
        }

        public void CommitTransaction()
        {
            if (dbConnector.dbConnection.State == System.Data.ConnectionState.Open)
            {
                dbConnector.dbTransaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (dbConnector.dbConnection.State == System.Data.ConnectionState.Open)
            {
                dbConnector.dbTransaction.Rollback();
            }
        }
    }
}
using HelpDesk.Domain.Interfaces.Repositories.DataConnector;

namespace HelpDesk.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IUsuarioRepository usuarioRepository { get; }
        IChamadoRepository chamadoRepository { get; }
        ITipoUsuarioRepository tipoUsuarioRepository { get; }

        IDbConnector dbConnector { get;}

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
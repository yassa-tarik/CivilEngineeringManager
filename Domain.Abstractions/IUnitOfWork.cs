using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IUnitOfWork
    {
        SqlConnection Connection { get; }

        SqlTransaction Transaction { get; }

        Task BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}

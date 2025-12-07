using Domain.Abstractions;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : DBConnectionStringBaseRepo, IUnitOfWork, IDisposable
    {
        //private readonly string _connectionString;

        public SqlConnection Connection { get; private set; }
        public SqlTransaction Transaction { get; private set; }

        public async Task BeginAsync()
        {
            //Connection = new SqlConnection();
            //await Connection.OpenAsync();
            Connection = await OpenConnectionAsync();
            Transaction = Connection.BeginTransaction();
        }

        public Task CommitAsync()
        {
            Transaction?.Commit();
            return Task.CompletedTask;
        }

        public Task RollbackAsync()
        {
            //Transaction?.Rollback();
            //return Task.CompletedTask;
            Transaction.Rollback();
            Connection.Close();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Connection?.Dispose();
        }
    }
}

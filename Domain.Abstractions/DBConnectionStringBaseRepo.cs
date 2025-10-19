using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public abstract class DBConnectionStringBaseRepo
    {
        protected readonly string _connectionString;

        protected DBConnectionStringBaseRepo()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        //Risk race condition
        protected SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.OpenAsync();
            return connection;
        }
        //TODO: will use this method later
        protected async Task<SqlConnection> OpenConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);

            // 1. Await the asynchronous operation
            await connection.OpenAsync();

            // 2. Return the now-open connection
            return connection;
        }
    }
}

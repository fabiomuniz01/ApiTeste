using Application.Common.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure.Persistence
{
    public class DapperDbConnectionFactory : IDapperDbConnectionFactory
    {
        private readonly string _connectionString;

        public DapperDbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetDbConnection()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}

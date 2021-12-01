﻿using DanskAkvakultur.dk.Shared.Configurations.Abstractions;
using System.Data.SqlClient;
using System.Text;

namespace DanskAkvakultur.dk.DataAccess.Factories
{
    /// <inheritdoc/>
    public class SqlDbConnectionFactory : IDbFactory
    {
        private readonly IConnectionSettings _connectionSettings;

        public SqlDbConnectionFactory(IConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }

        /// <inheritdoc/>
        public SqlConnection CreateConnection(string username, string password)
        {
            var connStr = CreateConnectionString(username, password);
            var sqlConn = new SqlConnection(connStr);
            return sqlConn;
        }

        private string CreateConnectionString(string username, string password)
        {
            var sb = new StringBuilder();
            sb.Append($"Server={_connectionSettings.ServerHost};");
            sb.Append($"Database={_connectionSettings.Database};");
            sb.Append($"User Id={username};");
            sb.Append($"Password={password};");

            return sb.ToString();
        }
    }
}

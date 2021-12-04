using DanskAkvakultur.dk.Shared.Configurations.Abstractions;
using System.Data.SqlClient;
using System.Text;

namespace DanskAkvakultur.dk.DataAccess.Factories
{
    /// <summary>
    /// Handles the creation of sql conention strings.
    /// </summary>
    public class SqlDbConnectionFactory : IDbFactory
    {
        /// <summary>
        /// Containts the settings of <see cref="IConnectionSettings"/>.
        /// </summary>
        private readonly IConnectionSettings _connectionSettings;

        /// <summary>
        /// This constructor initializes the new factory with dependencies of (<paramref name="connectionSettings"/>).
        /// </summary>
        /// <param name="connectionSettings">A required dependency for a connection settings.</param>
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

        /// <summary>
        /// Create a valid sql connection string.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>A connection string, based on a connection for sql servers.</returns>
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

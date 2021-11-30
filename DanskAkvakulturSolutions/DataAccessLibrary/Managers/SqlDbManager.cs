using DataAccessLibrary.Settings;
using System;
using System.Data.SqlClient;

namespace DataAccessLibrary.Managers
{
    public class SqlDbManager : IDbManager
    {
        private readonly IDbFactory _factory;

        public SqlDbManager(IDbFactory factory)
        {
            _factory = factory;
        }

        public SqlConnection GetSqlConnection(DbCredentialType connectionType) => connectionType switch
        {
            DbCredentialType.BasicUser => GetSqlConnectionBasicReader(),
            DbCredentialType.ComplexUser => GetSqlConnectionComplexSelect(),
            DbCredentialType.CreateUser => GetSqlConnectionCreatePermission(),
            DbCredentialType.UpdateUser => GetSqlConnectionUpdatePermission(),
            DbCredentialType.DeleteUser => GetSqlConnectionDeletePermission(),
            _ => throw new ArgumentException("No Connection Type found with used type.", nameof(connectionType))
        };

        /// <summary>
        /// For testing purposes only.
        /// </summary>
        /// <returns></returns>
        private SqlConnection GetTestSqlConnection() => _factory.CreateConnection("sa", "1234");

        private SqlConnection GetSqlConnectionBasicReader() => _factory.CreateConnection("BasicUserReader", "Pa$$w0rd");

        private SqlConnection GetSqlConnectionComplexSelect() => _factory.CreateConnection("ComplexUserReader", "Pa$$w0rd");

        private SqlConnection GetSqlConnectionDeletePermission() => _factory.CreateConnection("DeleteUserReader", "Pa$$w0rd");

        private SqlConnection GetSqlConnectionUpdatePermission() => _factory.CreateConnection("UpdateUserReader", "Pa$$w0rd");

        private SqlConnection GetSqlConnectionCreatePermission() => _factory.CreateConnection("CreateUserReader", "Pa$$w0rd");
    }
}

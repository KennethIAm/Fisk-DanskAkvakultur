using DanskAkvakultur.dk.DataAccess.Factories;
using DanskAkvakultur.dk.Shared.Enums;
using System;
using System.Data.SqlClient;

namespace DanskAkvakultur.dk.DataAccess.Managers
{
    /// <inheritdoc/>
    public class SqlDbManager : IDbManager
    {
        private readonly IDbFactory _factory;

        public SqlDbManager(IDbFactory factory)
        {
            _factory = factory;
        }

        /// <inheritdoc/>
        public SqlConnection GetSqlConnection(DbCredentialType connectionType) => connectionType switch
        {
            DbCredentialType.BasicUser => GetTestSqlConnection(),
            DbCredentialType.ComplexUser => GetTestSqlConnection(),
            DbCredentialType.CreateUser => GetTestSqlConnection(),
            DbCredentialType.UpdateUser => GetTestSqlConnection(),
            DbCredentialType.DeleteUser => GetTestSqlConnection(),
            _ => throw new ArgumentException("No Connection Type found with used type.", nameof(connectionType))
        };

        [Obsolete("When this method is used, it will show a warning. This method is only used for test purposes.")]
        private SqlConnection GetTestSqlConnection() => _factory.CreateConnection("sa", "Kode1234!");

        private SqlConnection GetSqlConnectionBasicReader() => _factory.CreateConnection("BasicUserReader", "Kode1234!");

        private SqlConnection GetSqlConnectionComplexSelect() => _factory.CreateConnection("ComplexUserReader", "Kode1234!");

        private SqlConnection GetSqlConnectionDeletePermission() => _factory.CreateConnection("DeleteUserReader", "Kode1234!");

        private SqlConnection GetSqlConnectionUpdatePermission() => _factory.CreateConnection("UpdateUserReader", "Kode1234!");

        private SqlConnection GetSqlConnectionCreatePermission() => _factory.CreateConnection("CreateUserReader", "Kode1234!");
    }
}

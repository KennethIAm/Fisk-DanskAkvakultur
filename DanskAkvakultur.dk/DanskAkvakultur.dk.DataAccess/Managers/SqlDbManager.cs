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

        /// <summary>
        /// This construcotr initializes a new SqlDbManager with dependencies of (<paramref name="factory"/>).
        /// </summary>
        /// <param name="factory">A required <see cref="IDbFactory"/> dependency.</param>
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

        /// <summary>
        /// Gets a connection, used for testing purposes only.
        /// </summary>
        /// <returns></returns>
        [Obsolete("When this method is used, it will show a warning. This method is only used for test purposes.")]
        private SqlConnection GetTestSqlConnection() => _factory.CreateConnection("sa", "Fisk123!");

        /// <summary>
        /// Gets a <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns>An initialized <see cref="SqlConnection"/> with the <see cref="DbCredentialType.BasicUser"/> permission.</returns>
        private SqlConnection GetSqlConnectionBasicReader() => _factory.CreateConnection("BasicUserReader", "Kode1234!");

        /// <summary>
        /// Gets a <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns>An initialized <see cref="SqlConnection"/>with the <see cref="DbCredentialType.ComplexUser"/> permission.</returns>
        private SqlConnection GetSqlConnectionComplexSelect() => _factory.CreateConnection("ComplexUserReader", "Kode1234!");

        /// <summary>
        /// Gets a <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns>An initialized <see cref="SqlConnection"/>with the <see cref="DbCredentialType.DeleteUser"/> permission.</returns>
        private SqlConnection GetSqlConnectionDeletePermission() => _factory.CreateConnection("DeleteUserReader", "Kode1234!");

        /// <summary>
        /// Gets a <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns>An initialized <see cref="SqlConnection"/>with the <see cref="DbCredentialType.UpdateUser"/> permission.</returns>
        private SqlConnection GetSqlConnectionUpdatePermission() => _factory.CreateConnection("UpdateUserReader", "Kode1234!");

        /// <summary>
        /// Gets a <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns>An initialized <see cref="SqlConnection"/>with the <see cref="DbCredentialType.CreateUser"/> permission.</returns>
        private SqlConnection GetSqlConnectionCreatePermission() => _factory.CreateConnection("CreateUserReader", "Kode1234!");
    }
}

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
            DbCredentialType.BASIC_READ => GetSqlConnectionBasicReader(),
            DbCredentialType.COMPLEX_READ => GetSqlConnectionComplexSelect(),
            DbCredentialType.CREATE_PERMISSION => GetSqlConnectionCreatePermission(),
            DbCredentialType.UPDATE_PERMISSION => GetSqlConnectionUpdatePermission(),
            DbCredentialType.DELETE_PERMISSION => GetSqlConnectionDeletePermission(),
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
        /// <returns>An initialized <see cref="SqlConnection"/> with the <see cref="DbCredentialType.BASIC_READ"/> permission.</returns>
        private SqlConnection GetSqlConnectionBasicReader() => _factory.CreateConnection("BasicReadLogin", "Kode1234!");

        /// <summary>
        /// Gets a <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns>An initialized <see cref="SqlConnection"/>with the <see cref="DbCredentialType.COMPLEX_READ"/> permission.</returns>
        private SqlConnection GetSqlConnectionComplexSelect() => _factory.CreateConnection("ComplexReadLogin", "Kode1234!");

        /// <summary>
        /// Gets a <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns>An initialized <see cref="SqlConnection"/>with the <see cref="DbCredentialType.DELETE_PERMISSION"/> permission.</returns>
        private SqlConnection GetSqlConnectionDeletePermission() => _factory.CreateConnection("DeletePermissionLogin", "Kode1234!");

        /// <summary>
        /// Gets a <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns>An initialized <see cref="SqlConnection"/>with the <see cref="DbCredentialType.UPDATE_PERMISSION"/> permission.</returns>
        private SqlConnection GetSqlConnectionUpdatePermission() => _factory.CreateConnection("UpdatePermissionLogin", "Kode1234!");

        /// <summary>
        /// Gets a <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns>An initialized <see cref="SqlConnection"/>with the <see cref="DbCredentialType.CREATE_PERMISSION"/> permission.</returns>
        private SqlConnection GetSqlConnectionCreatePermission() => _factory.CreateConnection("CreatePermissionLogin", "Kode1234!");
    }
}

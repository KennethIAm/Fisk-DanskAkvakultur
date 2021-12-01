using DanskAkvakultur.dk.Shared.Enums;
using System;
using System.Data.SqlClient;

namespace DanskAkvakultur.dk.DataAccess.Managers
{
    /// <summary>
    /// Represents a generic manager for accessing a database.
    /// </summary>
    public interface IDbManager
    {
        /// <summary>
        /// Get an <see cref="SqlConnection"/>.
        /// </summary>
        /// <param name="connectionType">Defines the credentials used for the sql connection.</param>
        /// <returns>An initialized sql connection.</returns>
        /// <exception cref="ArgumentException">Is thrown whenever a credential type isn't supported.</exception>
        SqlConnection GetSqlConnection(DbCredentialType connectionType);
    }
}

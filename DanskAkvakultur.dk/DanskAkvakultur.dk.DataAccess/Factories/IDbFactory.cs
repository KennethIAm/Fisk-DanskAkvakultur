using System.Data.SqlClient;

namespace DanskAkvakultur.dk.DataAccess.Factories
{
    /// <summary>
    /// Represents a generic database factory, for creating a connection with specified credentials.
    /// </summary>
    public interface IDbFactory
    {
        /// <summary>
        /// Initializes <see cref="SqlConnection"/> with the used credentials.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        SqlConnection CreateConnection(string username, string password);
    }
}

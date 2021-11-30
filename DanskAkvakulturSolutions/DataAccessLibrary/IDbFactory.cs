using System.Data.SqlClient;

namespace DataAccessLibrary
{
    public interface IDbFactory
    {
        SqlConnection CreateConnection(string username, string password);
    }
}

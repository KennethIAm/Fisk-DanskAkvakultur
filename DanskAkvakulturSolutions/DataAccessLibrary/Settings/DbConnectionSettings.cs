namespace DataAccessLibrary.Settings
{
    public class DbConnectionSettings : IConnectionSettings
    {
        public string ServerHost { get; set; }

        public string Database { get; set; }
    }
}

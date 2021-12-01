namespace DanskAkvakultur.dk.Shared.Configurations.Abstractions
{
    /// <summary>
    /// Represents a generic helper, for accessing connection properties.
    /// </summary>
    public interface IConnectionSettings
    {
        /// <summary>
        /// Gets the name of server host to connect to.
        /// </summary>
        public string ServerHost { get; }

        /// <summary>
        /// Gets the name of the database to connect with.
        /// </summary>
        public string Database { get; }
    }
}

using DanskAkvakultur.dk.Shared.Configurations.Abstractions;

namespace DanskAkvakultur.dk.Shared.Configurations
{
    /// <inheritdoc />
    public class SqlDbConnectionSettings : IConnectionSettings
    {
        /// <inheritdoc />
        public string ServerHost { get; set; }

        /// <inheritdoc />
        public string Database { get; set; }
    }
}

using DanskAkvakultur.dk.Shared.Configurations.Abstractions;
using System;

namespace DanskAkvakultur.dk.Shared.Configurations
{
    /// <inheritdoc />
    public class SimulationSettings : ISimulationHubSettings
    {
        /// <summary>
        /// The relative uri is set during Dependency Injection.
        /// </summary>
        public string RelativeUri { get; set; }

        /// <inheritdoc />
        public Uri AbsoluteUri { get; set; }

        /// <inheritdoc />
        public string GameEnginePath { get; set; }
    }
}

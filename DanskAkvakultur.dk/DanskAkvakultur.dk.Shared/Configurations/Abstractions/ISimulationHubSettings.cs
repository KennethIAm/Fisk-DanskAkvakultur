using System;

namespace DanskAkvakultur.dk.Shared.Configurations.Abstractions
{
    /// <summary>
    /// Represnts a generic helper, to access various properties of the simulation hub. 
    /// </summary>
    public interface ISimulationHubSettings
    {
        /// <summary>
        /// Gets the absolute uri of the relative uri. This property is set during runtime.
        /// </summary>
        public Uri AbsoluteUri { get; }

        /// <summary>
        /// Gets the path to the game engine file.
        /// </summary>
        public string GameEnginePath { get; set; }
    }
}

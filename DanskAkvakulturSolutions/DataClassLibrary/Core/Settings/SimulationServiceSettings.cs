using DataClassLibrary.Core.Settings.Interfaces;
using System;

namespace DataClassLibrary.Core.Settings
{
    public class SimulationServiceSettings : ISimulationSettings
    {
        public string RelativeUri { get; set; }

        public Uri AbsoluteUri { get; set; }

        public string GameEnginePath { get; set; }
    }
}

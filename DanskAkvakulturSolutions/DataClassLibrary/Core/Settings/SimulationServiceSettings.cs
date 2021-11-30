using DataClassLibrary.Core.Settings.Interfaces;
using System;

namespace DataClassLibrary.Core.Settings
{
    public class SimulationServiceSettings : ISimulationSettings
    {
        private string RelativeUri { get; set; }

        public Uri AbsoluteUri { get; set; }
    }
}

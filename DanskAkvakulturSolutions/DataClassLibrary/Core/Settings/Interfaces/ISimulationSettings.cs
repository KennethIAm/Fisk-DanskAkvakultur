using System;

namespace DataClassLibrary.Core.Settings.Interfaces
{
    public interface ISimulationSettings
    {
        public Uri AbsoluteUri { get; }

        public string GameEnginePath { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data.Settings
{
    public class SimulationSettings : ISimulationSettings
    {
        public string RelativeUri { get; set; }
    }
}

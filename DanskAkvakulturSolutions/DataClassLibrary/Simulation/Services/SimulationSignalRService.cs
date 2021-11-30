using DataClassLibrary.Core;
using DataClassLibrary.Core.Settings.Interfaces;
using DataClassLibrary.Simulation.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DataClassLibrary.Simulation.Services
{
    public class SimulationSignalRService : CoreHubConnectionService, ISimulationService
    {
        private readonly ILogger<SimulationSignalRService> _logger;
        private readonly ISimulationSettings _settings;

        public SimulationSignalRService(ILogger<SimulationSignalRService> logger, ISimulationSettings settings)
            : base(logger, settings.AbsoluteUri)
        {
            _logger = logger;
            _settings = settings;
        }

        public async Task ConnectAsync()
        {
            await base.StartConnectionAsync();
        }

        public async Task SendMessageAsync()
        {
            await base.SendAsync();
        }
    }
}

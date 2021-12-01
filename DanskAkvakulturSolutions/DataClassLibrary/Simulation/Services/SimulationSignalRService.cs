using DataClassLibrary.Core;
using DataClassLibrary.Core.Settings.Interfaces;
using DataClassLibrary.Simulation.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
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

        public async Task<bool> UpdateLeaderboardAsync(decimal value)
        {
            try
            {
                await HubConnection.SendAsync("UpdateLeaderboard", value);
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return false;
            }
        }
    }
}

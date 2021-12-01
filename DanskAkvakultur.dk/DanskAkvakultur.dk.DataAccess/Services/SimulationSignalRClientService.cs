using DanskAkvakultur.dk.DataAccess.Hubs;
using DanskAkvakultur.dk.DataAccess.Services.Abstrations;
using DanskAkvakultur.dk.Shared.Configurations.Abstractions;
using DanskAkvakultur.dk.Shared.Events;
using DanskAkvakultur.dk.Shared.Models.Score;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Services
{
    public class SimulationSignalRClientService : SignalRCoreHubService, ISimulationService
    {
        public event EventHandler<LeaderboardUpdatedEventArgs> LeaderboardUpdated;

        private readonly ILogger<SimulationSignalRClientService> _logger;
        private readonly ISimulationHubSettings _settings;

        public SimulationSignalRClientService(ILogger<SimulationSignalRClientService> logger, ISimulationHubSettings settings)
            : base(logger, settings.AbsoluteUri)
        {
            _logger = logger;
            _settings = settings;
        }

        protected override Task StartConnectionAsync()
        {
            HubConnection?.On<List<IScore>>("ReceiveLeaderboardData", (data) =>
            {
                var eventArgs = new LeaderboardUpdatedEventArgs
                {
                    ScoreData = data,
                    DataSetUpdated = DateTime.Now
                };

                LeaderboardUpdated?.Invoke(this, eventArgs);

                _logger.LogInformation($"Received leaderboard update from server.");
            });

            return base.StartConnectionAsync();
        }

        public async Task ConnectAsync()
        {
            await this.StartConnectionAsync();
        }

        public async Task<bool> UpdateLeaderboardAsync(decimal value)
        {
            try
            {
                await HubConnection.SendAsync("UpdateLeaderboard", value);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return false;
            }
        }
    }
}

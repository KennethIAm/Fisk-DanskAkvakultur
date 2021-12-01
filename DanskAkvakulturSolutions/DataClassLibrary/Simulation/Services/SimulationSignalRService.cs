using DataAccessLibrary.Leaderboard.Models;
using DataClassLibrary.Core;
using DataClassLibrary.Core.Events;
using DataClassLibrary.Core.Settings.Interfaces;
using DataClassLibrary.Simulation.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataClassLibrary.Simulation.Services
{
    public class SimulationSignalRService : CoreHubConnectionService, ISimulationService
    {
        public event EventHandler<LeaderboardUpdatedEventArgs> LeaderboardUpdated;

        private readonly ILogger<SimulationSignalRService> _logger;
        private readonly ISimulationSettings _settings;

        public SimulationSignalRService(ILogger<SimulationSignalRService> logger, ISimulationSettings settings)
            : base(logger, settings.AbsoluteUri)
        {
            _logger = logger;
            _settings = settings;
        }

        protected override Task StartConnectionAsync()
        {
            HubConnection?.On<List<ILeaderboard>>("ReceiveLeaderboardData", (data) =>
            {
                var eventArgs = new LeaderboardUpdatedEventArgs
                {
                    ScoreData = data,
                    DataSetUpdated = DateTime.Now
                };

                LeaderboardUpdated?.Invoke(this, eventArgs);

                _logger.LogInformation($"Received message from server: {typeof(object)}");
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
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return false;
            }
        }
    }
}

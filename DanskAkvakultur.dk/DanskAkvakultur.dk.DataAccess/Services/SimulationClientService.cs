using DanskAkvakultur.dk.DataAccess.Hubs;
using DanskAkvakultur.dk.DataAccess.Services.Abstrations;
using DanskAkvakultur.dk.Shared.Configurations.Abstractions;
using DanskAkvakultur.dk.Shared.Events;
using DanskAkvakultur.dk.Shared.Models.Score;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Services
{
    public class SimulationClientService : SignalRCoreHubService, ISimulationService
    {
        private readonly ILogger<SimulationClientService> _logger;
        private readonly ISimulationHubSettings _settings;

        public SimulationClientService(ILogger<SimulationClientService> logger, ISimulationHubSettings settings)
            : base(logger, settings.AbsoluteUri)
        {
            _logger = logger;
            _settings = settings;
        }

        protected virtual void OnLeaderboardUpdated(LeaderboardUpdatedEventArgs e)
        {
            EventHandler<LeaderboardUpdatedEventArgs> handler = LeaderboardUpdated;

            if (handler is not null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnAnimalChoosen(PlayerAnimalChoiceEventArgs e)
        {
            EventHandler<PlayerAnimalChoiceEventArgs> handler = AnimalChoosen;

            if (handler is not null)
            {
                handler(this, e);
            }
        }

        protected override Task StartConnectionAsync()
        {
            HubConnection?.On<ScoreModel[]>("ReceiveLeaderboardData", (data) =>
            {
                _logger.LogInformation($"Received leaderboard data from server with test {data}");

                var args = new LeaderboardUpdatedEventArgs
                {
                    ScoreData = data.ToList<IScore>(),
                    DataSetUpdated = DateTime.Now
                };

                OnLeaderboardUpdated(args);
            });

            HubConnection?.On<string, string>("ReceiveAnimalInformationData", (name, data) =>
            {
                _logger.LogInformation("Received animal information data from server.");

                var args = new PlayerAnimalChoiceEventArgs
                {
                    AnimalName = name,
                    Information = data
                };

                OnAnimalChoosen(args);
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

        public async Task<bool> UpdateAnimalInformationAsync(string name)
        {
            try
            {
                await HubConnection.SendAsync("GetAnimalInformation", name);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return false;
            }
        }

        public event EventHandler<LeaderboardUpdatedEventArgs> LeaderboardUpdated;

        public event EventHandler<PlayerAnimalChoiceEventArgs> AnimalChoosen;
    }
}

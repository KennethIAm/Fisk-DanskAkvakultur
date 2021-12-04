using DanskAkvakultur.dk.DataAccess.Hubs;
using DanskAkvakultur.dk.DataAccess.Services.Abstrations;
using DanskAkvakultur.dk.Shared.Configurations.Abstractions;
using DanskAkvakultur.dk.Shared.Events;
using DanskAkvakultur.dk.Shared.Models.Information;
using DanskAkvakultur.dk.Shared.Models.Score;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Services
{
    /// <summary>
    /// This service handles the client requests from the Virtual Simulation Hub, which inherits <see cref="SignalRCoreHubService"/> and implements <see cref="ISimulationService"/>.
    /// </summary>
    public class SimulationClientService : SignalRCoreHubService, ISimulationService
    {
        private readonly ILogger<SimulationClientService> _logger;
        private readonly ISimulationHubSettings _settings;

        /// <summary>
        /// This constructor initializes a new SimulationClientService, with the required dependencies of 
        /// (<paramref name="logger"/>, <paramref name="settings"/>). This contructor uses the Absolute Uri of the <see cref="ISimulationHubSettings"/> to the base.
        /// </summary>
        /// <param name="logger">A required dependency used for logging purposes.</param>
        /// <param name="settings">A required dependency used for getting the setting to the Simulation Hub.</param>
        public SimulationClientService(ILogger<SimulationClientService> logger, ISimulationHubSettings settings)
            : base(logger, settings.AbsoluteUri)
        {
            _logger = logger;
            _settings = settings;
        }

        /// <summary>
        /// Invokes the <see cref="LeaderboardUpdatedEventArgs"/> event handler.
        /// </summary>
        /// <param name="e">The event to invoke.</param>
        protected virtual void OnLeaderboardUpdated(LeaderboardUpdatedEventArgs e)
        {
            EventHandler<LeaderboardUpdatedEventArgs> handler = LeaderboardUpdated;

            if (handler is not null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Invokes the <see cref="PlayerAnimalChoiceEventArgs"/> event handler.
        /// </summary>
        /// <param name="e">The event to invoke.</param>
        protected virtual void OnAnimalChoosen(PlayerAnimalChoiceEventArgs e)
        {
            EventHandler<PlayerAnimalChoiceEventArgs> handler = AnimalChoosen;

            if (handler is not null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Starts a connection to the hub. With registered handlers which are invoked on the hub, whenever the methods are called. (ReceiveLeaderboardData, ReceiveAnimalInformationData).
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation that connects to the hub.</returns>
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

            HubConnection?.On<AnimalInformation>("ReceiveAnimalInformationData", (information) =>
            {
                _logger.LogInformation("Received animal information data from server.");

                var args = new PlayerAnimalChoiceEventArgs
                {
                    Information = information
                };

                OnAnimalChoosen(args);
            });

            return base.StartConnectionAsync();
        }

        /// <inheritdoc/>
        public async Task ConnectAsync()
        {
            await this.StartConnectionAsync();
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public event EventHandler<LeaderboardUpdatedEventArgs> LeaderboardUpdated;

        /// <inheritdoc/>
        public event EventHandler<PlayerAnimalChoiceEventArgs> AnimalChoosen;
    }
}

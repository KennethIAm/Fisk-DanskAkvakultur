using DanskAkvakultur.dk.DataAccess.Repositories.Abstractions;
using DanskAkvakultur.dk.Shared.Models.Score;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.Shared.Hubs.Endpoints
{
    /// <summary>
    /// Handles the communication between the client and servers of clients connected to the Virtual Simulation Hub.
    /// </summary>
    public class VirtualSimulationHubEndpoint : Hub
    {
        private readonly ILogger<VirtualSimulationHubEndpoint> _logger;
        private readonly IScoreRepository _scoreRepository;
        private readonly IAnimalInformationRepository _informationRepository;

        /// <summary>
        /// This constructor initializes the new VirtualSimulationHubEndpoint with dependencies of
        /// (<paramref name="logger"/>, <paramref name="scoreRepository"/>, <paramref name="informationRepository"/>).
        /// </summary>
        /// <param name="logger">A required dependency used for logging purposes.</param>
        /// <param name="scoreRepository">A required dependency for accessing score data.</param>
        /// <param name="informationRepository">A required dependency for accessing animal information data.</param>
        public VirtualSimulationHubEndpoint(ILogger<VirtualSimulationHubEndpoint> logger, IScoreRepository scoreRepository, IAnimalInformationRepository informationRepository)
        {
            _logger = logger;
            _scoreRepository = scoreRepository;
            _informationRepository = informationRepository;
        }

        /// <summary>
        /// Overrides the base.OnConnectedAsync, used to handle when clients connects to the hub.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous client connecting.</returns>
        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation($"Client {Context.ConnectionId} now online!");

            var leaderboard = await _scoreRepository.GetAllAsync();
            await Clients.Caller.SendAsync("ReceiveLeaderboardData", leaderboard.ToArray());

            _logger.LogInformation($"Updating client {Context.ConnectionId} with leaderboard.");

            await base.OnConnectedAsync();
        }

        /// <summary>
        /// Overrides the base.OnDisconnectedAsync, used to handle when clients disconnects from the hub.
        /// </summary>
        /// <param name="exception">The specified exception if any occurred. Otherwise null.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous process of a client disconnecitng.</returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (exception is not null)
            {
                _logger.LogWarning($"Client {Context.ConnectionId} disconnected with error message: {exception.Message}");
            }
            else
            {
                _logger.LogInformation($"Client {Context.ConnectionId} now offline!");
            }

            return base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// A Hub method, for sending animal information to the caller.
        /// </summary>
        /// <param name="name">The name of the animal to get information from.</param>
        /// <returns>A <see cref="Task"/> representing the asynchrous call, sending the animal information to the caller.</returns>
        [HubMethodName("GetAnimalInformation")]
        public async Task GetAnimalInformationAsync(string name)
        {
            _logger.LogInformation($"Getting information from animal {name}");

            var information = await _informationRepository.GetByNameAsync(name);

            if (information is not null)
            {
                await Clients.Caller.SendAsync("ReceiveAnimalInformationData", information);
            }
        }

        /// <summary>
        /// A Hub method, for updating the leaderboad with the given score.
        /// </summary>
        /// <remarks>
        /// This methods creates the new score, then updates all clients connected to the hub.
        /// </remarks>
        /// <param name="score">A score given to the client.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation updating the leaderboard.</returns>
        [HubMethodName("UpdateLeaderboard")]
        public async Task UpdateLeaderboardAsync(decimal score)
        {
            var obj = new ScoreModel
            {
                ClientId = Guid.NewGuid(),
                Score = score,
                ScoreRegistered = DateTime.Now
            };

            var result = await _scoreRepository.CreateAsync(obj);

            if (!result.Equals(Guid.Empty))
            {
                _logger.LogInformation($"Leaderboard has been updated with score {score}");

                var leaderboard = await _scoreRepository.GetAllAsync();

                await Clients.Caller.SendAsync("ReceiveLeaderboardData", leaderboard.ToArray());
            }
        }

        [HubMethodName("SendMessage")]
        public async Task SendMessageAsync(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

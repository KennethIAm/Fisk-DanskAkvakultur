using DanskAkvakultur.dk.DataAccess.Repositories.Abstractions;
using DanskAkvakultur.dk.Shared.Models.Score;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.Shared.Hubs.Endpoints
{
    public class VirtualSimulationHubEndpoint : Hub
    {
        private readonly ILogger<VirtualSimulationHubEndpoint> _logger;
        private readonly IScoreRepository _scoreRepository;
        private readonly IAnimalInformationRepository _informationRepository;

        public VirtualSimulationHubEndpoint(ILogger<VirtualSimulationHubEndpoint> logger, IScoreRepository scoreRepository, IAnimalInformationRepository informationRepository)
        {
            _logger = logger;
            _scoreRepository = scoreRepository;
            _informationRepository = informationRepository;
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation($"Client {Context.ConnectionId} now online!");

            var leaderboard = await _scoreRepository.GetAllAsync();
            await Clients.Caller.SendAsync("ReceiveLeaderboardData", leaderboard.ToArray());

            _logger.LogInformation($"Updating client {Context.ConnectionId} with leaderboard.");

            await base.OnConnectedAsync();
        }

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

        public async Task GetAnimalInformation(string name)
        {
            _logger.LogInformation($"Getting information from animal {name}");

            var information = await _informationRepository.GetByNameAsync(name);

            if (information is not null)
            {
                await Clients.Caller.SendAsync("ReceiveAnimalInformationData", information);
            }
        }

        public async Task UpdateLeaderboard(decimal score)
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

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

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

        public VirtualSimulationHubEndpoint(ILogger<VirtualSimulationHubEndpoint> logger)
        {
            _logger = logger;
        }

        public override Task OnConnectedAsync()
        {
            _logger.LogInformation($"Client {Context.ConnectionId} now online!");

            return base.OnConnectedAsync();
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

        public async Task UpdateAnimalInformation(string name)
        {

        }

        public async Task UpdateLeaderboard(decimal score)
        {
            await Clients.Caller.SendAsync("ReceiveLeaderboardData", new List<object>
            {
                Context.ConnectionId,
                score,
                37.21,
                457.38
            });

            //await Clients.Caller.SendAsync("ReceiveLeaderboardData", new List<IScore>
            //{
            //    new ScoreModel
            //    {
            //        ClientId = Guid.NewGuid(),
            //        Score = score,
            //        ScoreRegistered = DateTime.Now
            //    },
            //    new ScoreModel
            //    {
            //        ClientId = Guid.NewGuid(),
            //        Score = 37.21M,
            //        ScoreRegistered = DateTime.Now
            //    },
            //    new ScoreModel
            //    {
            //        ClientId = Guid.NewGuid(),
            //        Score =  457.38M,
            //        ScoreRegistered = DateTime.Now
            //    }
            //});
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

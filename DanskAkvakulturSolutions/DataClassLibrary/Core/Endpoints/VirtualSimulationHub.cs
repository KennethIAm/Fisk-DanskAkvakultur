using DataAccessLibrary.Leaderboard.Repository;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DataClassLibrary.Core.Endpoints
{
    public class VirtualSimulationHub : Hub
    {
        private readonly ILogger<VirtualSimulationHub> _logger;
        private readonly ILeaderboardRepository _leaderboardRepository;

        public VirtualSimulationHub(ILogger<VirtualSimulationHub> logger, ILeaderboardRepository leaderboardRepository)
        {
            _logger = logger;
            _leaderboardRepository = leaderboardRepository;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task UpdateLeaderboard(float score)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", Context.ConnectionId, $"Updated leaderboard with score {score}.");
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

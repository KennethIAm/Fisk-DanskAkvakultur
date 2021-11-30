using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data.Hubs
{
    public class SimulationHub : Hub
    {
        private readonly ILogger<SimulationHub> _logger;

        public SimulationHub(ILogger<SimulationHub> logger)
        {
            _logger = logger;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        [Obsolete("This is a test method, not to be used by any clients.")]
        public async Task Test()
        {
            _logger.LogInformation($"Client [{Context.ConnectionId}], started a virtual session.");
            await Clients.Caller.SendAsync("ReceiveMessage", $"{Context.ConnectionId}", "Welcome to the hub.");
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

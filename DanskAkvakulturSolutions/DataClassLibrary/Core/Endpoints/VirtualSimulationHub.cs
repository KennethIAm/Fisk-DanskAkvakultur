using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DataClassLibrary.Core.Endpoints
{
    public class VirtualSimulationHub : Hub
    {
        private readonly ILogger<VirtualSimulationHub> _logger;

        public VirtualSimulationHub(ILogger<VirtualSimulationHub> logger)
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

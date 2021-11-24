using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data.Services
{
    public class SimulationService : IAsyncDisposable
    {
        private HubConnection _hubConnection;
        private ILogger<SimulationService> _logger;

        public SimulationService(ILogger<SimulationService> logger)
        {
            _logger = logger;
        }

        public bool IsConnected => _hubConnection.State == HubConnectionState.Connected;

        public async Task ConnectToHubAsync(Uri absoluteUri)
        {
            _hubConnection = new HubConnectionBuilder()
            .WithUrl(absoluteUri)
            .Build();

            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var encodedMsg = $"{user}: {message}";

                _logger.LogInformation($"Received message from server: {encodedMsg}");
            });

            await _hubConnection.StartAsync();

            await _hubConnection.SendAsync("Test");
        }

        public async Task SendMessageAsync()
        {
            await _hubConnection.SendAsync("SendMessage", $"{_hubConnection.ConnectionId}", "Hello, I'm also doing a simulation!");
        }

        public async ValueTask DisposeAsync()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.DisposeAsync();

                _logger.LogInformation($"Disposed {nameof(_hubConnection)}");
            }
        }
    }    
}

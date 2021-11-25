using BlazorServer.Data.Settings;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BlazorServer.Data.Hubs
{
    /// <summary>
    /// Handles the core of a Hub. 
    /// <br>
    /// Handling the connection to a hub, provides the access to check connection state and ability to send or receive messages.
    /// </br>
    /// </summary>
    public abstract class CoreHub : IAsyncDisposable
    {
        private readonly ILogger<object> _logger;
        private readonly ISimulationSettings _simulationSettings;
        private readonly HubConnection _hubConnection;

        protected CoreHub(ILogger<object> logger, ISimulationSettings simulationSettings, NavigationManager nav)
        {
            _logger = logger;
            _simulationSettings = simulationSettings;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(nav.ToAbsoluteUri(_simulationSettings.RelativeUri))
                .Build();
        }

        protected virtual async Task StartConnectionAsync()
        {
            _hubConnection?.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var encodedMsg = $"{user}: {message}";

                _logger.LogInformation($"Received message from server: {encodedMsg}");
            });

            await _hubConnection.StartAsync();
        }

        protected virtual async Task SendAsync()
        {
            await _hubConnection.SendAsync("SendMessage", $"{ConnectionId}", "Hello, I'm also doing a simulation!");
        }

        ///// <summary>
        ///// Returns the state of the connection. True if connected, otherwise false.
        ///// </summary>
        public bool IsConnected => 
            _hubConnection.State == HubConnectionState.Connected;

        /// <summary>
        /// Gets the connection id. This value is cleared when no connection is made.
        /// </summary>
        protected string ConnectionId => 
            _hubConnection.ConnectionId;

        /// <summary>
        /// Disposes the <see cref="HubConnection"/>.
        /// </summary>
        /// <returns></returns>
        async ValueTask IAsyncDisposable.DisposeAsync() => 
            await _hubConnection.DisposeAsync();
    }
}

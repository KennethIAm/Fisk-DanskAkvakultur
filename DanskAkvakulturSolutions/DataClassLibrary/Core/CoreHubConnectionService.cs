using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DataClassLibrary.Core
{
    public class CoreHubConnectionService : IAsyncDisposable
    {
        private readonly ILogger<CoreHubConnectionService> _logger;
        private readonly HubConnection _hubConnection;

        protected CoreHubConnectionService(ILogger<CoreHubConnectionService> logger, Uri absoluteUri)
        {
            _logger = logger;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(absoluteUri)
                .Build();
        }

        public HubConnection HubConnection => _hubConnection;

        /// <summary>
        /// Starts a default connection with the hub.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous start.</returns>
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

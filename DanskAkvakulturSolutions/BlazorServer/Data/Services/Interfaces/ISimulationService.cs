using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data.Services.Interfaces
{
    public interface ISimulationService : IAsyncDisposable
    {
        ///// <summary>
        ///// Returns the state of the connection. True if connected, otherwise false.
        ///// </summary>
        public bool IsConnected { get; }

        /// <summary>
        /// Send message to the Hub.
        /// </summary>
        /// <returns>A task representing the asynchronous process that sends the message to the hub.</returns>
        Task SendMessageAsync();

        /// <summary>
        /// Connects directly to the base of a Hub. This should only be called once.
        /// </summary>
        /// <returns>A task representing the asynchronous process which connects to a hub.</returns>
        Task ConnectAsync();
    }
}

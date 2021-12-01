using DataClassLibrary.Core.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataClassLibrary.Simulation.Services.Interfaces
{
    public interface ISimulationService : IAsyncDisposable
    {
        public event EventHandler<LeaderboardUpdatedEventArgs> LeaderboardUpdated;

        ///// <summary>
        ///// Returns the state of the connection. True if connected, otherwise false.
        ///// </summary>
        public bool IsConnected { get; }

        Task<bool> UpdateLeaderboardAsync(decimal value);

        /// <summary>
        /// Connects directly to the base of a Hub. This should only be called once.
        /// </summary>
        /// <returns>A task representing the asynchronous process which connects to a hub.</returns>
        Task ConnectAsync();
    }
}

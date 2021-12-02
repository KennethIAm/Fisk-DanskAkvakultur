using DanskAkvakultur.dk.Shared.Events;
using System;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Services.Abstrations
{
    /// <summary>
    /// Represents a generic service, to access various propeties and methods regarding a simulation.
    /// </summary>
    public interface ISimulationService : IAsyncDisposable
    {
        /// <summary>
        /// Is fired when the leaderboard has been updated from the game.
        /// </summary>
        public event EventHandler<LeaderboardUpdatedEventArgs> LeaderboardUpdated;

        /// <summary>
        /// Is fired when a players pick an animal from the game.
        /// </summary>
        public event EventHandler<PlayerAnimalChoiceEventArgs> AnimalChoosen;

        ///// <summary>
        ///// Returns the state of the connection. True if connected, otherwise false.
        ///// </summary>
        public bool IsConnected { get; }

        Task<bool> UpdateLeaderboardAsync(decimal value);

        Task<bool> UpdateAnimalInformationAsync(string name);

        /// <summary>
        /// Connects directly to the base of a Hub. This should only be called once.
        /// </summary>
        /// <returns>A task representing the asynchronous process which connects to a hub.</returns>
        Task ConnectAsync();
    }
}

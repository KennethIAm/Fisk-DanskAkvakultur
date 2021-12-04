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

        /// <summary>
        /// Updates the leaderboard with a given value.
        /// </summary>
        /// <param name="value">Represents the value to be created on the leaderbaord.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation returning true if succeed otherwise false.</returns>
        Task<bool> UpdateLeaderboardAsync(decimal value);

        /// <summary>
        /// Updates the animal information data by given animal name.
        /// </summary>
        /// <param name="name">Represents the name of the animal.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation returning true if the animal was found, otherwise false.</returns>
        Task<bool> UpdateAnimalInformationAsync(string name);

        /// <summary>
        /// Connects directly to the base of a Hub. This should only be called once.
        /// </summary>
        /// <returns>A task representing the asynchronous process which connects to a hub.</returns>
        Task ConnectAsync();
    }
}

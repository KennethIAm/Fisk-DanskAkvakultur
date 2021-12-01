using DanskAkvakultur.dk.Shared.Models.Score;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Repositories.Abstractions
{
    /// <summary>
    /// Represents a generic Score Repository, used to access a leaderboard.
    /// </summary>
    public interface IScoreRepository
    {
        /// <summary>
        /// Gets a collection of scores on the leaderboard.
        /// </summary>
        /// <returns>A <see cref="Task"/>, representing the asynchronous <see cref="List{T}"/>.</returns>
        Task<List<IScore>> GetAllAsync();

        /// <summary>
        /// Creates a new score for the leaderboard.
        /// </summary>
        /// <param name="leaderboard">A generic </param>
        /// <returns>A <see cref="Task"/> representing the asynchronous <see cref="Guid"/> assigned to the leaderboard.</returns>
        Task<Guid> CreateAsync(IScore leaderboard);
    }
}

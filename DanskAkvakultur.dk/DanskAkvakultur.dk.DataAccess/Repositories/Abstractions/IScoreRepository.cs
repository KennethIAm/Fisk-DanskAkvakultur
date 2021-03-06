using DanskAkvakultur.dk.Shared.Models.Score;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Repositories.Abstractions
{
    /// <summary>
    /// Represents a generic Score Repository, provides the ability to access data within the repository.
    /// </summary>
    public interface IScoreRepository
    {
        /// <summary>
        /// Gets a collection of scores on the leaderboard.
        /// </summary>
        /// <returns>A <see cref="Task"/>, representing the asynchronous <see cref="List{IScore}"/>.</returns>
        Task<List<IScore>> GetAllAsync();

        /// <summary>
        /// Creates a new score for the leaderboard.
        /// </summary>
        /// <param name="score">A generic <see cref="IScore"/> to be created in the leaderboard.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous <see cref="Guid"/> assigned to the score.</returns>
        Task<Guid> CreateAsync(IScore score);
    }
}

using DataAccessLibrary.Leaderboard.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.Leaderboard.Repository
{
    public interface ILeaderboardRepository
    {
        Task<List<ILeaderboard>> GetAsync();
        Task<Guid> CreateAsync(ILeaderboard leaderboard);
    }
}

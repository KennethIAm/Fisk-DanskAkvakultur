using System;

namespace DataAccessLibrary.Leaderboard.Models
{
    public interface ILeaderboard
    {
        Guid ClientId { get; }
        float Score { get; }
        DateTime ScoreRegistered { get; }
    }
}
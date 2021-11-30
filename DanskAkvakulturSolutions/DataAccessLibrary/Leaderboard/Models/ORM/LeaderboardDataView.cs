using System;

namespace DataAccessLibrary.Leaderboard.Models.ORM
{
    public class LeaderboardDataView
    {
        public Guid ClientId { get; set; }
        public decimal Score { get; set; }
        public DateTime Registered { get; set; }
    }
}

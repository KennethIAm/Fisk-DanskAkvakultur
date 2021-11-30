using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Leaderboard.Models
{
    public class Leaderboard : ILeaderboard
    {
        public Guid ClientId { get; set; }
        public float Score { get; set; }
        public DateTime ScoreRegistered { get; set; }
    }
}

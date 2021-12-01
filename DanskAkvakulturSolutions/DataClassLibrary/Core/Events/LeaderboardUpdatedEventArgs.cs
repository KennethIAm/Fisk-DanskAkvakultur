using DataAccessLibrary.Leaderboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClassLibrary.Core.Events
{
    public class LeaderboardUpdatedEventArgs : EventArgs
    {
        public List<ILeaderboard> ScoreData { get; set; }
        public DateTime DataSetUpdated { get; set; }
    }
}

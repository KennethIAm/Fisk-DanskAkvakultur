using DanskAkvakultur.dk.Shared.Models.Score;
using System;
using System.Collections.Generic;

namespace DanskAkvakultur.dk.Shared.Events
{
    /// <summary>
    /// Provides the ability to share data when a leaderboard is updated.
    /// </summary>
    public class LeaderboardUpdatedEventArgs : EventArgs
    {
        public List<IScore> ScoreData { get; set; }
        public DateTime DataSetUpdated { get; set; }
    }
}

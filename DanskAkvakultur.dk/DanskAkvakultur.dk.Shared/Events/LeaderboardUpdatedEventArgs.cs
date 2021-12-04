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
        /// <summary>
        /// Gets the leaderboard data. This property is populated whenever the even is fired.
        /// </summary>
        public List<IScore> ScoreData { get; set; }

        /// <summary>
        /// Gets the data of when the data was last updated. This property is set when the data is updated.
        /// </summary>
        public DateTime DataSetUpdated { get; set; }
    }
}

using System;

namespace DanskAkvakultur.dk.Shared.Models.Score
{
    /// <inheritdoc />
    public class ScoreModel : IScore
    {
        /// <inheritdoc />
        public Guid ClientId { get; set; }

        /// <inheritdoc />
        public decimal Score { get; set; }

        /// <inheritdoc />
        public DateTime ScoreRegistered { get; set; }
    }
}

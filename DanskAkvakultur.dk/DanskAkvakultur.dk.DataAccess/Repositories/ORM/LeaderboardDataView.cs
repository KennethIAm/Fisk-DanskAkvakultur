using System;

namespace DanskAkvakultur.dk.DataAccess.Repositories.ORM
{
    /// <summary>
    /// This class represents a one-to-one mapped database entity.
    /// </summary>
    public class LeaderboardDataView
    {
        /// <inheritdoc />
        public Guid Client_ID { get; set; }

        /// <inheritdoc />
        public decimal Score { get; set; }

        /// <inheritdoc />
        public DateTime SubmitDate { get; set; }
    }
}

using System;

namespace DanskAkvakultur.dk.DataAccess.Repositories.ORM
{
    /// <summary>
    /// This class is an ORM, used to map entitie(s) from a data source with a one-to-one relationship.
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

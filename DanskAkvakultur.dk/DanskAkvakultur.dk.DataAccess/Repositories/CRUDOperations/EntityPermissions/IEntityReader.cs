using DanskAkvakultur.dk.Shared.Models.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Repositories.CRUDOperations.EntityPermissions
{
    /// <summary>
    /// Provides needed methods for accessing read-only data.
    /// </summary>
    /// <typeparam name="TAggregate"></typeparam>
    /// <typeparam name="KCriteria"></typeparam>
    public interface IEntityReader<TAggregate, KCriteria> where TAggregate : IAggregateRoot
    {
        /// <summary>
        /// Get all entities in the data source.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{TAggregate}<"/> if any found, otherwise <see cref="Enumerable.Empty"/> is returned.</returns>
        public Task<IEnumerable<TAggregate>> GetAllAsync();

        /// <summary>
        /// Get the entity, in the data source that matches the <see cref="KCriteria"/>.
        /// </summary>
        /// <param name="keyValue">Defines a key described as the primary key in the data source.</param>
        /// <returns>A <see cref="TAggregate"/> if found, otherwise null.</returns>
        public Task<TAggregate> GetByIdAsync(KCriteria keyValue);
    }
}

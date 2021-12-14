using DanskAkvakultur.dk.Shared.Models.Abstractions;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Repositories.CRUDOperations.EntityPermissions
{
    /// <summary>
    /// Provides needed methods for updating stored data.
    /// </summary>
    /// <typeparam name="TAggregate"></typeparam>
    public interface IEntityUpdate<TAggregate> where TAggregate : IAggregateRoot
    {
        /// <summary>
        /// Updates an entity in the data source.
        /// </summary>
        /// <param name="data">Represents the entity to be updated.</param>
        /// <returns><see cref="TAggregate"/> if it was successfully updated, otherwise null.</returns>
        public Task<TAggregate> UpdateAsync(TAggregate data);
    }
}

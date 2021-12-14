using DanskAkvakultur.dk.Shared.Models.Abstractions;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Repositories.CRUDOperations.EntityPermissions
{
    /// <summary>
    /// Provides needed methods for removing data.
    /// </summary>
    /// <typeparam name="TAggregate"></typeparam>
    public interface IEntityRemover<TAggregate> where TAggregate : IAggregateRoot
    {
        /// <summary>
        /// Removes the entity from the data source.
        /// </summary>
        /// <param name="data">Represents the dataset to remove.</param>
        /// <returns>True if the entity was deleted, otherwise false.</returns>
        public Task<bool> RemoveAsync(TAggregate data);
    }
}

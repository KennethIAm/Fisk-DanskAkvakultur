using DanskAkvakultur.dk.Shared.Models.Abstractions;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Repositories.CRUDOperations.EntityPermissions
{
    /// <summary>
    /// Provides needed methods for storing data.
    /// </summary>
    /// <typeparam name="TAggregate"></typeparam>
    public interface IEntityCreator<TAggregate, KCriteria> where TAggregate : IAggregateRoot
    {
        /// <summary>
        /// Creates an entity, described by the <see cref="TAggregate"/>.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<KCriteria> CreateAsync(TAggregate data);
    }
}

using DanskAkvakultur.dk.Shared.Models.Abstractions;
using System.Collections.Generic;
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
        public Task<IEnumerable<TAggregate>> GetAllAsync();

        public Task<TAggregate> GetByIdAsync(KCriteria keyValue);
    }
}

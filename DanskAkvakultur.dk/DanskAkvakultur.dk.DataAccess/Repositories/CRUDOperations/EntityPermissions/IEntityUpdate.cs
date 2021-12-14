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
        public Task<TAggregate> UpdateAsync(TAggregate data);
    }
}

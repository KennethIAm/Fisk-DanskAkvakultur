using DanskAkvakultur.dk.Shared.Models.Abstractions;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Repositories.CRUDOperations.EntityPermissions
{
    /// <summary>
    /// Provides needed methods for storing data.
    /// </summary>
    /// <typeparam name="TAggregate"></typeparam>
    public interface IEntityCreator<TAggregate> where TAggregate : IAggregateRoot
    {
        public Task<TAggregate> CreateAsync(TAggregate data);
    }
}

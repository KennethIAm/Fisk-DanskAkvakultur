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
        public Task<bool> RemoveAsync(TAggregate data);
    }
}

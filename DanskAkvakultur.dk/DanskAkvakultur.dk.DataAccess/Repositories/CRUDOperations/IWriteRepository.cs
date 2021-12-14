using DanskAkvakultur.dk.DataAccess.Repositories.CRUDOperations.EntityPermissions;
using DanskAkvakultur.dk.Shared.Models.Abstractions;

namespace DanskAkvakultur.dk.DataAccess.Repositories.CRUDOperations
{
    /// /// <summary>
    /// Represents a generic repository, which defines all Write methods common for all repositories.
    /// </summary>
    /// <typeparam name="TAggregate">Represents the aggregate, which inherits <see cref="IAggregateRoot"/>.</typeparam>
    /// <typeparam name="KCriteria">Is used to identify the key used in the <see cref="TAggregate"/>.</typeparam>
    public interface IWriteRepository<TAggregate, KCriteria> : IEntityCreator<TAggregate, KCriteria>, IEntityUpdate<TAggregate>, IEntityRemover<TAggregate>
        where TAggregate : IAggregateRoot
    { }
}

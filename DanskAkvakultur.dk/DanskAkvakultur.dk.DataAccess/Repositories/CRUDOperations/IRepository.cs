using DanskAkvakultur.dk.DataAccess.Repositories.CRUDOperations.EntityPermissions;
using DanskAkvakultur.dk.Shared.Models.Abstractions;

namespace DanskAkvakultur.dk.DataAccess.Repositories.CRUDOperations
{
    /// <summary>
    /// Represents a generic repository, which defines all Read-Write methods common for all repositories.
    /// </summary>
    /// <typeparam name="TAggregate">Represents the aggregate, which inherits <see cref="IAggregateRoot"/>.</typeparam>
    /// <typeparam name="KCriteria">Is used to identify the key used in the <see cref="TAggregate"/>.</typeparam>
    public interface IRepository<TAggregate, KCriteria> :
        IEntityReader<TAggregate, KCriteria>,
        IEntityCreator<TAggregate>,
        IEntityRemover<TAggregate>,
        IEntityUpdate<TAggregate>
        where TAggregate : IAggregateRoot
    { }
}

using DanskAkvakultur.dk.Shared.Models.Information;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Repositories.Abstractions
{
    /// <summary>
    /// Represents a generic Animal Information Repository, provides the ability to access data within the repository.
    /// </summary>
    public interface IAnimalInformationRepository
    {
        /// <summary>
        /// Gets the information about the given animal if found.
        /// </summary>
        /// <param name="name">Name of the animal.</param>
        /// <returns>A <see cref="Task"/> that represents a asynchronous animal information.</returns>
        Task<AnimalInformation> GetByNameAsync(string name);
    }
}

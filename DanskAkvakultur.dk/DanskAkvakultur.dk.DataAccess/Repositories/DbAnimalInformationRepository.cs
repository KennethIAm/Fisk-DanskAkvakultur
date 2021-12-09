using DanskAkvakultur.dk.DataAccess.Managers;
using DanskAkvakultur.dk.DataAccess.Repositories.Abstractions;
using DanskAkvakultur.dk.DataAccess.Repositories.ORM;
using DanskAkvakultur.dk.Shared.Enums;
using DanskAkvakultur.dk.Shared.Models.Information;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Repositories
{
    /// <inheritdoc/>
    public class DbAnimalInformationRepository : IAnimalInformationRepository
    {
        private readonly IDbManager _dbManager;

        /// <summary>
        /// This constructor initializes a new DbAnimalInformationRepository, with the required dependencies of (<paramref name="dbManager"/>).
        /// </summary>
        /// <param name="dbManager">A required <see cref="IDbManager"/>, used to manage several features in the repository.</param>
        public DbAnimalInformationRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        /// <inheritdoc/>
        public async Task<AnimalInformation> GetByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name), "Coudln't get information for animal. Name was null or empty.");

            AnimalInformation info = null;

            using (var conn = _dbManager.GetSqlConnection(DbCredentialType.BASIC_READ))
            {
                var proc = "[GetAnimalInformationByName]";
                var values = new
                {
                    @name = name
                };

                var result = await conn.QuerySingleAsync<DisplayAnimalInformationView>(proc, values, commandType: CommandType.StoredProcedure);

                if (result is not null)
                {
                    info = new AnimalInformation
                    {
                        Animal = new Animal
                        {
                            Name = result.AnimalName,
                            AnimalType = new AnimalType
                            {
                                Name = result.AnimalType
                            }
                        },
                        BriefDescription = result.BriefDescription,
                        HabitatDescription = result.HabitatDescription,
                        LastUpdated = result.LastUpdated
                    };
                }
            }

            return info;
        }
    }
}

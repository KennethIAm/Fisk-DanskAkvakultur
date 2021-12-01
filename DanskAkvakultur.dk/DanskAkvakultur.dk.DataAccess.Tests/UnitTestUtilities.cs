using DanskAkvakultur.dk.DataAccess.Factories;
using DanskAkvakultur.dk.DataAccess.Managers;
using DanskAkvakultur.dk.DataAccess.Repositories;
using DanskAkvakultur.dk.DataAccess.Repositories.Abstractions;
using DanskAkvakultur.dk.Shared.Configurations;
using Microsoft.Extensions.Configuration;
using System;

namespace DanskAkvakultur.dk.DataAccess.Tests
{
    public static class UnitTestUtilities
    {
        public static object SetupRepositoryTest(string repository) => repository switch
        {
            nameof(IScoreRepository) =>
                new DbScoreRepository(GetRepositoryDependencies()),
            _ => throw new ArgumentOutOfRangeException(nameof(repository), "Given repository is not valid.")
        };

        private static IDbManager GetRepositoryDependencies()
        {
            var config = BuildConfiguration();

            var settings = config.GetSection("DbConfig").Get<SqlDbConnectionSettings>();
            var factory = new SqlDbConnectionFactory(settings);
            return new SqlDbManager(factory);
        }

        private static IConfiguration BuildConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddUserSecrets("79df6715-fc77-4ac6-b0c7-a46f855447ce");

            return config.Build();
        }
    }
}

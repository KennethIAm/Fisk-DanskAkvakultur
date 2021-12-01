using DanskAkvakultur.dk.DataAccess.Managers;
using DanskAkvakultur.dk.DataAccess.Repositories.Abstractions;
using DanskAkvakultur.dk.DataAccess.Repositories.ORM;
using DanskAkvakultur.dk.Shared.Enums;
using DanskAkvakultur.dk.Shared.Models.Score;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.DataAccess.Repositories
{
    /// <inheritdoc />
    public class DbScoreRepository : IScoreRepository
    {
        private readonly IDbManager _dbManager;

        public DbScoreRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task<Guid> CreateAsync(IScore obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj), "Couldn't create score, due to score being null.");

            if (obj.ClientId.Equals(Guid.Empty))
                throw new ArgumentException("Couldn't create score, due to client id being empty.", nameof(obj));

            if (obj.Score.Equals(decimal.Zero) || obj.Score < decimal.Zero)
                throw new ArgumentException("Coudln't create score, due to score being zero or negative.", nameof(obj));

            if (obj.ScoreRegistered.Equals(default))
                throw new ArgumentException("Couldn't create score, registration datetime is default.", nameof(obj));

            Guid entityId;
            using (var conn = _dbManager.GetSqlConnection(DbCredentialType.CreateUser))
            {
                string proc = "[CreateLeaderboardScore]";
                var values = new
                {
                    @clientId = obj.ClientId,
                    @score = obj.Score,
                    @registrationTimestamp = obj.ScoreRegistered
                };

                entityId = await conn.ExecuteScalarAsync<Guid>(proc, values, commandType: CommandType.StoredProcedure);
            }

            return entityId;
        }

        public async Task<List<IScore>> GetAllAsync()
        {
            List<IScore> leaderboard = new();

            using (var conn = _dbManager.GetSqlConnection(DbCredentialType.BasicUser))
            {
                string proc = "[GetLeaderboard]";

                var queryResults = await conn.QueryAsync<LeaderboardDataView>(proc, commandType: CommandType.StoredProcedure);

                if (queryResults is not null && queryResults.Any())
                {
                    foreach (var result in queryResults)
                    {
                        var score = new ScoreModel
                        {
                            ClientId = result.ClientId,
                            Score = result.Score,
                            ScoreRegistered = result.ScoreRegistered
                        };

                        leaderboard.Add(score);
                    }
                }
            }

            return leaderboard;
        }
    }
}

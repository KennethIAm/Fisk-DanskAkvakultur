using Dapper;
using DataAccessLibrary.Leaderboard.Models;
using DataAccessLibrary.Leaderboard.Models.ORM;
using DataAccessLibrary.Managers;
using DataAccessLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary.Leaderboard.Repository
{
    public class DbLeaderboardRepository : ILeaderboardRepository
    {
        private readonly IDbManager _dbManager;

        public DbLeaderboardRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task<Guid> CreateAsync(ILeaderboard leaderboard)
        {
            Guid entityId;
            using (var conn = _dbManager.GetSqlConnection(DbCredentialType.CreateUser))
            {
                string proc = "[CreateLeaderboardScore]";
                var values = new
                {
                    @clientId = leaderboard.ClientId,
                    @score = leaderboard.Score,
                    @registrationTimestamp = leaderboard.ScoreRegistered
                };

                entityId = await conn.ExecuteScalarAsync<Guid>(proc, values, commandType: CommandType.StoredProcedure);
            }

            return entityId;
        }

        public async Task<List<ILeaderboard>> GetAsync()
        {
            List<ILeaderboard> scores = new();

            using (var conn = _dbManager.GetSqlConnection(DbCredentialType.BasicUser))
            {
                string proc = "[GetLeaderboard]";

                var queryResults = await conn.QueryAsync<LeaderboardDataView>(proc, commandType: CommandType.StoredProcedure);

                if (queryResults is not null && queryResults.Any())
                {
                    foreach (var result in queryResults)
                    {
                        var leaderboard = new Models.Leaderboard
                        {
                            ClientId = result.ClientId,
                            Score = (float)result.Score,
                            ScoreRegistered = result.Registered
                        };

                        scores.Add(leaderboard);
                    }
                }
            }

            return scores;
        }
    }
}

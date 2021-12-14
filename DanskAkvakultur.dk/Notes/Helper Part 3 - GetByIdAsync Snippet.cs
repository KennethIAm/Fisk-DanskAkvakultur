using System.Data.SqlClient;

/// <inheritdoc/>
public async Task<IScore> GetByIdAsync(Guid keyValue)
{
    IScore score = null;

    using (SqlConnection conn = _dbManager.GetSqlConnection(DbCredentialType.BASIC_READ))
    {
        string cmdText = "SELECT * FROM [LeaderboardDataView] L WHERE L.[Client_ID] = @keyValue;";
        var values = new
        {
            @keyValue = keyValue
        };

        LeaderboardDataView result = await conn.QuerySingleAsync<LeaderboardDataView>(cmdText, values, commandType: CommandType.Text);

        if (result is not null)
        {
            score = new ScoreModel
            {
                ClientId = result.Client_ID,
                Score = result.Score,
                ScoreRegistered = result.SubmitDate
            };
        }
    }

    return score;
}
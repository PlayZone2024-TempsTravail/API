using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Worktime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;

namespace PlayZone.DAL.Repositories.Worktime_Related;

public class WorktimeRepository : IWorktimeRepository
{
    private readonly NpgsqlConnection _connection;
    private IWorktimeRepository _worktimeRepositoryImplementation;

    public WorktimeRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public int Create(Worktime worktime)
    {
        const string query = @"
            INSERT INTO ""WorkTime""(
                ""start"",
                ""end"",
                ""isonsite"",
                ""category_id"",
                ""project_id"",
                ""user_id""
             )
            VALUES(
                @StartTime,
                @EndTime,
                @IsOnSite,
                @WorktimeCategoryId,
                @ProjectId,
                @UserId
            )
            RETURNING ""id_WorkTime"" AS ""IdWorkTime"";
       ";
        int resultId = this._connection.QuerySingle<int>(query, new
        {
            worktime.StartTime,
            worktime.EndTime,
            worktime.IsOnSite,
            worktime.WorktimeCategoryId,
            worktime.ProjectId,
            worktime.UserId
        });
        return resultId;
    }

    public Worktime? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id_WorkTime"" AS ""IdWorkTime"",
                ""start"" AS ""StartTime"",
                ""end"" AS ""EndTime"",
                ""isonsite"" AS ""IsOnSite"",
                ""category_id"" AS ""WorktimeCategoryId"",
                ""project_id"" AS ""ProjectId"",
                ""user_id"" AS ""UserId""
            FROM ""WorkTime""
            WHERE ""id_WorkTime"" = @IdWorkTime;
        ";
        return this._connection.QuerySingleOrDefault<Worktime>(query, new { IdWorkTime = id });
    }

    public IEnumerable<Worktime> GetByDay(int idUser, int dayOfMonth)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Worktime> GetByWeek(int idUser, int weekOfYear)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Worktime> GetByMonth(int idUser, int monthOfYear)
    {
        throw new NotImplementedException();
    }

    public bool CheckIfWorktimeExists(int idUser, DateTime start, DateTime end)
    {
        const string query = @"
            SELECT count(*)
            FROM ""WorkTime""
            WHERE user_id = @UserId
                AND (@start  BETWEEN ""start"" AND ""end""
                OR @end BETWEEN ""start"" AND ""end"");

        ";
        return this._connection.QuerySingle<int>(query, new { UserId = idUser, start = start, end = end }) > 0;
    }
}

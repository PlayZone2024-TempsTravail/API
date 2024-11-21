using System.Data.Common;
using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Worktime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;

namespace PlayZone.DAL.Repositories.Worktime_Related;

public class WorktimeRepository : IWorktimeRepository
{
    private readonly NpgsqlConnection _connection;

    public WorktimeRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<Worktime> GetByDay(int userId, int dayOfMonth)
    {
        const string query = @"
            SELECT *
            FROM ""WorkTime""
            WHERE EXTRACT(DAY FROM ""start"") = @DayOfMonth AND ""user_id"" = @UserId;
        ";
        return this._connection.Query<Worktime>(query, new { DayOfMonth = dayOfMonth, UserId = userId });
    }

    public IEnumerable<Worktime> GetByWeek(int userId, int weekOfYear)
    {
        const string query = @"
            SELECT *
            FROM ""WorkTime""
            WHERE EXTRACT(WEEK FROM ""start"") = @WeekOfYear AND ""user_id"" = @UserId;
        ";
        return this._connection.Query<Worktime>(query, new { WeekOfYear = weekOfYear, UserId = userId });
    }

    public IEnumerable<Worktime> GetByMonth(int userId, int monthOfYear)
    {
        const string query = @"
            SELECT *
            FROM ""WorkTime""
            WHERE EXTRACT(MONTH FROM ""start"") = @MonthOfYear AND ""user_id"" = @UserId;
        ";
        return this._connection.Query<Worktime>(query, new { MonthOfYear = monthOfYear, UserId = userId });
    }
}

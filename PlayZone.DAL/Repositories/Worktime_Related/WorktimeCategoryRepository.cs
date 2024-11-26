using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Worktime_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;

namespace PlayZone.DAL.Repositories.Worktime_Related;

public class WorktimeCategoryRepository : IWorktimeCategoryRepository
{
    private readonly NpgsqlConnection _connection;

    public WorktimeCategoryRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<WorktimeCategory> GetAll()
    {
        const string query = @"
            SELECT
                ""id_workTime_category"" AS ""IdWorktimeCategory"",
                ""name"",
                ""color""
            FROM ""WorkTime_Category"";
        ";
        return this._connection.Query<WorktimeCategory>(query);
    }

    public WorktimeCategory? GetById(string id)
    {
        const string query = @"
            SELECT
                ""id_workTime_category"" AS ""IdWorktimeCategory"",
                ""name"",
                ""color""
            FROM ""WorkTime_Category""
            WHERE ""id_workTime_category"" = @IdWorktimeCategory;
        ";
        return this._connection.QuerySingleOrDefault<WorktimeCategory>(query, new { IdWorktimeCategory = id });
    }

    public string Create(WorktimeCategory worktimeCategory)
    {
        const string query = @"
                INSERT INTO ""WorkTime_Category"" (
                   ""id_workTime_category"",
                   ""name"",
                   ""color""
                   )
                VALUES (
                    @IdWorktimeCategory,
                    @Name,
                    @Color
                    )
                RETURNING ""id_workTime_category"";
        ";
        string resultId = this._connection.QuerySingle<string>(query, new
        {
            IdWorktimeCategory = worktimeCategory.IdWorktimeCategory,
            Name = worktimeCategory.Name,
            Color = worktimeCategory.Color
        });

        return resultId;
    }

    public bool Update(WorktimeCategory worktimeCategory)
    {
        const string query = @"
            UPDATE ""WorkTime_Category"" SET
                ""name"" = @Name,
                ""color"" = @Color
            WHERE ""id_workTime_category"" = @IdWorktimeCategory;
            ";
        int affectedRows = this._connection.Execute(query, new
        {
            IdWorktimeCategory = worktimeCategory.IdWorktimeCategory,
            Name = worktimeCategory.Name,
            Color = worktimeCategory.Color
        });
        return affectedRows > 0;
    }

    public bool Delete(string id)
    {
        const string query = @"DELETE FROM ""WorkTime_Category"" WHERE ""id_workTime_category"" = @IdWorktimeCategory;";
        int affectedRows = this._connection.Execute(query, new { IdWorktimeCategory = id });
        return affectedRows > 0;
    }
}

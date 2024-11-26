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
                ""isActive"",
                ""abreviation"",
                ""name"",
                ""color""
            FROM ""WorkTime_Category"";
        ";
        return this._connection.Query<WorktimeCategory>(query);
    }

    public WorktimeCategory? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id_workTime_category"" AS ""IdWorktimeCategory"",
                ""isActive"",
                ""abreviation"",
                ""name"",
                ""color""
            FROM ""WorkTime_Category""
            WHERE ""id_workTime_category"" = @IdWorktimeCategory;
        ";
        return this._connection.QuerySingleOrDefault<WorktimeCategory>(query, new { IdWorktimeCategory = id });
    }

    public int Create(WorktimeCategory worktimeCategory)
    {
        const string query = @"
                INSERT INTO ""WorkTime_Category"" (
                   ""isActive"",
                   ""abreviation"",
                   ""name"",
                   ""color""
                   )
                VALUES (
                    @IsActive,
                    @Abreviation,
                    @Name,
                    @Color
                    )
                RETURNING ""id_workTime_category"";
        ";
        int resultId = this._connection.QuerySingle<int>(query, new
        {
            IdWorktimeCategory = worktimeCategory.IdWorktimeCategory,
            IsActive = worktimeCategory.IsActive,
            Abreviation = worktimeCategory.Abreviation,
            Name = worktimeCategory.Name,
            Color = worktimeCategory.Color
        });

        return resultId;
    }

    public bool Update(WorktimeCategory worktimeCategory)
    {
        const string query = @"
            UPDATE ""WorkTime_Category"" SET
                ""isActive"" = @IsActive,
                ""abreviation"" = @Abreviation,
                ""name"" = @Name,
                ""color"" = @Color
            WHERE ""id_workTime_category"" = @IdWorktimeCategory;
            ";
        int affectedRows = this._connection.Execute(query, new
        {
            IdWorktimeCategory = worktimeCategory.IdWorktimeCategory,
            IsActive = worktimeCategory.IsActive,
            Abreviation = worktimeCategory.Abreviation,
            Name = worktimeCategory.Name,
            Color = worktimeCategory.Color
        });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""WorkTime_Category"" WHERE ""id_workTime_category"" = @IdWorktimeCategory;";
        int affectedRows = this._connection.Execute(query, new { IdWorktimeCategory = id });
        return affectedRows > 0;
    }
}

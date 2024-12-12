using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Entities.Worktime_Related;
using PlayZone.DAL.Interfaces.User_Related;
using PlayZone.DAL.Interfaces.Worktime_Related;

namespace PlayZone.DAL.Repositories.User_Related;

public class CompteurWorktimeCategoryRepository : ICompteurWorktimeCategoryRepository
{
    private readonly NpgsqlConnection _connection;

    public CompteurWorktimeCategoryRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<CompteurWorktimeCategory> GetAll()
    {
        const string query = @"
            SELECT
                ""user_id"" AS ""UserId"",
                ""workTime_category_id"" AS ""WorkTimeCategoryId"",
                ""quantity"" AS ""Quantity""
            FROM ""Compteur_WorkTime_Category"";
        ";
        return this._connection.Query<CompteurWorktimeCategory>(query);
    }

    public IEnumerable<CompteurWorktimeCategory> GetByUser(int userId)
    {
        const string query = @"
            SELECT
                ""workTime_category_id"" AS ""WorkTimeCategoryId"",
                ""quantity"" AS ""Quantity""
            FROM ""Compteur_WorkTime_Category""
            WHERE ""user_id"" = @UserId;
        ";
        return this._connection.Query<CompteurWorktimeCategory>(query, new { UserId = userId });
    }

    public CompteurWorktimeCategory Create(CompteurWorktimeCategory compteurWorktimeCategory)
    {
        const string query = @"
            INSERT INTO ""Compteur_WorkTime_Category""
            VALUES (
                    @userId,
                    @worktimeCategoryId,
                    @quantity
                    )
            RETURNING ""user_id"" AS ""userId"", ""workTime_category_id"" AS ""worktimeCategoryId"";
        ";
        return this._connection.QuerySingle<CompteurWorktimeCategory>(query, new { userId = compteurWorktimeCategory.UserId, worktimeCategoryId = compteurWorktimeCategory.WorktimeCategoryId, quantity = compteurWorktimeCategory.Quantity });
    }

    public bool Update(CompteurWorktimeCategory compteurWorktimeCategory)
    {
        const string query = @"
                UPDATE ""Compteur_WorkTime_Category"" SET
                    ""quantity"" = @Quantity
            WHERE ""user_id"" = @userId AND ""workTime_category_id"" = @worktimeCategoryId;
            ";
        int affectedRows = this._connection.Execute(query, new
        {
            worktimeCategoryId = compteurWorktimeCategory.WorktimeCategoryId,
            userId = compteurWorktimeCategory.UserId,
            Quantity = compteurWorktimeCategory.Quantity
        });
        return affectedRows > 0;
    }

    public bool Delete(int userId, int worktimeCategoryId)
    {
        const string query = @"
            DELETE FROM ""Compteur_WorkTime_Category""
            WHERE ""user_id"" = @userId AND ""workTime_category_id"" = @worktimeCategoryId;
        ";
        int affectedRows = this._connection.Execute(query, new { userId = userId, worktimeCategoryId = worktimeCategoryId });
        return affectedRows > 0;
    }
}

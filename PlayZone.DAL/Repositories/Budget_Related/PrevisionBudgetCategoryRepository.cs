using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.DAL.Repositories.Budget_Related;

public class PrevisionBudgetCategoryRepository : IPrevisionBudgetCategoryRepository
{
    private readonly NpgsqlConnection _connection;
    public PrevisionBudgetCategoryRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<PrevisionBudgetCategory> GetByProjectId(int projectId)
    {
        const string query = @"
            SELECT
                ""id_prevision_budget_category"" AS ""idPrevisionBudgetCategory"" ,
                ""project_id"" AS ""projectId"",
                ""category_id"" AS ""categoryId"",
                ""date"",
                ""motif"",
                ""montant""
            FROM ""Prevision_Budget_Category""
            WHERE ""project_id"" = @projectId;
        ";
        return this._connection.Query<PrevisionBudgetCategory>(query, new { projectId = projectId });
    }

    public PrevisionBudgetCategory? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id_prevision_budget_category"" AS ""idPrevisionBudgetCategory"" ,
                ""project_id"" AS ""projectId"",
                ""category_id"" AS ""categoryId"",
                ""date"",
                ""motif"",
                ""montant""
            FROM ""Prevision_Budget_Category""
            WHERE ""id_prevision_budget_category"" = @id;
        ";
        return this._connection.QuerySingleOrDefault<PrevisionBudgetCategory>(query, new { id = id });
    }

    public int Create(PrevisionBudgetCategory pbc)
    {
        const string query = @"
            INSERT INTO ""Prevision_Budget_Category""
            VALUES (DEFAULT, @projectId, @categoryId, @date, @motif, @montant)
            RETURNING ""id_prevision_budget_category"" AS ""IdUser"";
        ";
        return this._connection.QuerySingleOrDefault<int>(query, new
        {
            projectId = pbc.projectId,
            categoryId = pbc.categoryId,
            date = pbc.date,
            motif = pbc.motif,
            montant = pbc.montant
        });
    }

    public bool Update(PrevisionBudgetCategory previsionBudgetCategory)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        const string query = @"
            DELETE FROM ""Prevision_Budget_Category""
            WHERE ""id_prevision_budget_category"" = @id;
        ";
        int affectedRows = this._connection.Execute(query, new { id });
        return affectedRows > 0;
    }
}

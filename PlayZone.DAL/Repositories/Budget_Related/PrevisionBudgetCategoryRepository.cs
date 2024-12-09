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
                p.""id_prevision_budget_category"" AS ""idPrevisionBudgetCategory"" ,
                p.""project_id"" AS ""projectId"",
                p.""category_id"" AS ""categoryId"",
                c.name AS ""categoryName"",
                p.""date"",
                p.""motif"",
                p.""montant"",
                c.""isIncome"" AS ""IsIncome""
            FROM ""Prevision_Budget_Category"" p
            INNER JOIN ""Category"" c ON p.category_id = c.id_category
            WHERE ""project_id"" = @projectId
        ";
        return this._connection.Query<PrevisionBudgetCategory>(query, new { projectId = projectId });
    }

    public PrevisionBudgetCategory? GetById(int id)
    {
        const string query = @"
            SELECT
                p.""id_prevision_budget_category"" AS ""idPrevisionBudgetCategory"" ,
                p.""project_id"" AS ""projectId"",
                p.""category_id"" AS ""categoryId"",
                c.name AS ""categoryName"",
                p.""date"",
                p.""motif"",
                p.""montant"",
                c.""isIncome"" AS ""IsIncome""
            FROM ""Prevision_Budget_Category"" p
            INNER JOIN ""Category"" c ON p.category_id = c.id_category
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
            projectId = pbc.ProjectId,
            categoryId = pbc.CategoryId,
            date = pbc.Date,
            motif = pbc.Motif,
            montant = pbc.Montant
        });
    }

    public bool Update(PrevisionBudgetCategory previsionBudgetCategory)
    {
        const string query = @"
            UPDATE ""Prevision_Budget_Category""
            SET
                ""date"" = @date,
                ""montant"" = @montant,
                ""motif"" = @motif
            WHERE ""id_prevision_budget_category"" = @id;
        ";
        int affectedRows = this._connection.Execute(query, new
        {
            id = previsionBudgetCategory.IdPrevisionBudgetCategory,
            date = previsionBudgetCategory.Date,
            montant = previsionBudgetCategory.Montant,
            motif = previsionBudgetCategory.Motif
        });
        return affectedRows > 0;
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

using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.DAL.Repositories.Budget_Related;

public class CategoryRepository : ICategoryRepository
{
    private readonly NpgsqlConnection _connection;

    public CategoryRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<Category> GetAll()
    {
        const string query = @"
            SELECT
                ""id_category"" AS ""IdCategory"",
                ""name"" AS ""Name"",
                ""isIncome"" AS ""IsIncome"",
                ""EstimationParCategorie""
            FROM ""Category"";
    ";
    return this._connection.Query<Category>(query);
    }

    public Category? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id_category"" AS ""IdCategory"",
                ""name"" AS ""Name"",
                ""isIncome"" AS ""IsIncome"",
                ""EstimationParCategorie""
            FROM ""Category""
            WHERE ""id_category"" = @idCategory;
    ";
        return this._connection.QuerySingleOrDefault<Category>(query, new { idCategory = id });
    }

    public int Create(Category category)
    {
        const string query = @"
            INSERT INTO ""Category"" (
                ""name"",
                ""isIncome"",
                ""EstimationParCategorie""
                )
            VALUES (
                    @Name,
                    @IsIncome,
                    @EstimationParCategorie
                    )
                RETURNING ""id_category""
    ";
    int resultId = this._connection.QuerySingle<int>(query, new
        {
            Name = category.Name,
            IsIncome = category.IsIncome,
            EstimationParCategorie = category.EstimationParCategorie
        });

    return resultId;
    }

    public bool Update(Category category)
    {
        const string query = @"
            UPDATE ""Category"" SET
                ""name"" = @Name,
                ""isIncome"" = @IsIncome,
                ""EstimationParCategorie"" = @EstimationParCategorie
            WHERE ""id_category"" = @IdCategory
        ";
        int affectedRows = this._connection.Execute(query, new
        {
            Name = category.Name,
            IsIncome = category.IsIncome,
            EstimationParCategorie = category.EstimationParCategorie,
            IdCategory = category.IdCategory
        });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""Category"" WHERE ""id_category"" = @IdCategory";
        int affectedRows = this._connection.Execute(query, new { IdCategory = id });
        return affectedRows > 0;
    }
}

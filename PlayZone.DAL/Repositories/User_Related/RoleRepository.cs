using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.DAL.Repositories.User_Related;

public class RoleRepository : IRoleRepository
{
    private readonly NpgsqlConnection _connection;

    public RoleRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<Role> GetAll()
    {
        const string query = @"
            SELECT
                ""id_role"" AS IdRole,
                ""name"",
                ""isRemovable"",
                ""isVisible""
            FROM ""Role""
            ORDER BY ""id_role"";
        ";
        return this._connection.Query<Role>(query);
    }

    public Role? GetById(int id)
    {
        const string query = @"
            SELECT
                ""id_role"" AS IdRole,
                ""name"",
                ""isRemovable"",
                ""isVisible""
            FROM ""Role""
            WHERE ""id_role"" = @Id;
        ";
        return this._connection.QuerySingleOrDefault<Role>(query, new { Id = id });
    }

    public int Create(Role role)
    {
        const string query = @"
            INSERT INTO ""Role"" (""name"")
            VALUES (@Name) RETURNING id_role
        ";
        return this._connection.QuerySingle<int>(query, new { Name = role.Name });
    }

    public bool Update(Role role)
    {
        const string query = @"
            UPDATE ""Role""
            SET ""name"" = @Name
            WHERE ""id_role"" = @IdRole;
        ";
        int affectedRows = this._connection.Execute(query, new { Name = role.Name, IdRole = role.IdRole });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""Role"" WHERE ""id_role"" = @Id;";
        int affectedRows = this._connection.Execute(query, new { Id = id });
        return affectedRows > 0;
    }
}


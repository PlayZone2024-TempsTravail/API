using System.Data.Common;
using Dapper;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.DAL.Repositories.User_Related;

public class RoleRepository : IRoleRepository
{
    private readonly DbConnection _connection;

    public RoleRepository(DbConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<Role> GetAll()
    {
        const string query = @"SELECT * FROM ""Role""";
        return this._connection.Query<Role>(query);
    }

    public Role? GetById(int id)
    {
        const string query = @"SELECT * FROM ""Role"" WHERE ""id_role"" = @Id;";
        return this._connection.QuerySingleOrDefault<Role>(query, new { Id = id });
    }

    public Role Create(Role role)
    {
        const string query = @"INSERT INTO ""Role"" (id_role, name) VALUES (@IdRole, @Name);";
        return this._connection.QuerySingle<Role>(query, new { IdRole = role.IdRole, Name = role.Name });
    }

    public bool Update(Role role)
    {
        const string query = @"UPDATE ""Role"" SET name = @Name WHERE id_role = @IdRole";
        int affectedRows = this._connection.Execute(query, new { Name = role.Name, IdRole = role.IdRole });
        return affectedRows > 0;
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""Role"" WHERE ""id_role"" = @IdRole";
        int affectedRows = this._connection.Execute(query, new { IdRole = id });
        return affectedRows > 0;
    }
}


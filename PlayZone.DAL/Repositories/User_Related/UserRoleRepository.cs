using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.DAL.Repositories.User_Related;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly NpgsqlConnection _connection;
    public UserRoleRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<UserRole> GetAll()
    {
        const string query = @"
            SELECT
                ""role_id"" AS ""RoleId"",
                ""user_id"" AS ""UserId""
            FROM ""User_Role"";
        ";
        return this._connection.Query<UserRole>(query);
    }

    public IEnumerable<int> GetByUser(int idUser)
    {
        const string query = @"
            SELECT role_id
            FROM ""User_Role""
            WHERE user_id = @userId;
        ";
        return this._connection.Query<int>(query, new {userId = idUser});
    }

    public UserRole Create(UserRole userRole)
    {
        const string query = @"
            INSERT INTO ""User_Role""
            VALUES (@userId, @roleId)
            RETURNING ""role_id"" AS ""roleId"", ""user_id"" AS ""userId"";
        ";
        return this._connection.QuerySingle<UserRole>(query, new { userId = userRole.UserId, roleId = userRole.RoleId });
    }

    public bool Delete(int roleId, int userId)
    {
        const string query = @"
            DELETE FROM ""User_Role""
            WHERE ""role_id"" = @roleId AND ""user_id"" = @userId
        ";
        int affectedRows = this._connection.Execute(query, new { userId = userId, roleId = roleId });
        return affectedRows > 0;
    }
}

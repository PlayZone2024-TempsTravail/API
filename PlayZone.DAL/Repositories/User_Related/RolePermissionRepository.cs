using System.Data;
using System.Data.Common;
using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.DAL.Repositories.User_Related;

public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly NpgsqlConnection _connection;

    public RolePermissionRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<RolePermission> GetAll()
    {
        const string query = @"
            SELECT
                ""role_id"" AS ""RoleId"",
                ""permission_id"" AS ""PermissionId""
            FROM ""Role_Permission"";
        ";
        return this._connection.Query<RolePermission>(query);
    }

    public IEnumerable<RolePermission> GetByRole(int roleId)
    {
        const string query = @"
            SELECT
                ""role_id"" AS ""RoleId"",
                ""permission_id"" AS ""PermissionId""
            FROM ""Role_Permission""
            WHERE ""role_id"" = @RoleId;
        ";
        return this._connection.Query<RolePermission>(query, new { RoleId = roleId });
    }

    public RolePermission Create(RolePermission rolePermission)
    {
        const string query = @"
            INSERT INTO ""Role_Permission"" (""role_id"", ""permission_id"")
            VALUES (@RoleId, @PermissionId)
            RETURNING ""role_id"" AS ""roleId"", ""permission_id"" AS ""permissionId"";
        ";
        return this._connection.QuerySingle<RolePermission>(query, new
        {
            RoleId = rolePermission.RoleId,
            PermissionId = rolePermission.PermissionId
        });
    }

    public bool CheckPermission(int userId, string permission)
    {
        const string query = @"
            SELECT CASE WHEN count(*) <> 0 THEN TRUE ELSE FALSE END
            FROM (
                SELECT u.id_user, rp.permission_id
                FROM ""User"" u
                LEFT JOIN ""Role"" r ON u.id_user = r.id_role
                LEFT JOIN ""Role_Permission"" rp ON r.id_role = rp.role_id
                WHERE u.id_user = @UserId AND rp.permission_id = @PermissionId
            ) data;
        ";
        return this._connection.QuerySingle<bool>(query, new {UserId= userId, PermissionId = permission});
    }

    public bool Delete(int roleId, string permissionId)
    {
        const string query = @"
            DELETE FROM ""Role_Permission""
            WHERE ""role_id"" = @RoleId AND ""permission_id"" = @PermissionId;
        ";
        int affectedRows = this._connection.Execute(query, new { RoleId = roleId, PermissionId = permissionId });
        return affectedRows > 0;
    }
}


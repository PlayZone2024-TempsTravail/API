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
            SELECT ""role_id"", ""permission_id""
            FROM ""Role_Permission"";
        ";
        return this._connection.Query<RolePermission>(query);
    }

    public IEnumerable<RolePermission> GetByRole(int roleId)
    {
        const string query = @"
            SELECT ""role_id"", ""permission_id""
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
            RETURNING ""role_id"", ""permission_id"";
        ";
        return this._connection.QuerySingle<RolePermission>(query, new
        {
            RoleId = rolePermission.RoleId,
            PermissionId = rolePermission.PermissionId
        });
    }

    public bool Delete(int roleId, int permissionId)
    {
        const string query = @"
            DELETE FROM ""Role_Permission""
            WHERE ""role_id"" = @RoleId AND ""permission_id"" = @PermissionId;
        ";
        int affectedRows = this._connection.Execute(query, new { RoleId = roleId, PermissionId = permissionId });
        return affectedRows > 0;
    }
}


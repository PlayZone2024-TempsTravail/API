using System.Data.Common;
using Dapper;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.DAL.Repositories.User_Related;

public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly DbConnection _connection;

    public RolePermissionRepository(DbConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<RolePermission> GetAll()
    {
        const string query = @"SELECT * FROM ""Role_Permission""";
        return this._connection.Query<RolePermission>(query);
    }

    public IEnumerable<RolePermission> GetByRole(int id)
    {
        const string query = @"SELECT * FROM ""Role_Permission"" WHERE ""role_id"" = @Id;";
        return this._connection.Query<RolePermission>(query, new { Id = id });
    }

    public RolePermission Create(RolePermission rolePermission)
    {
        const string query = @"INSERT INTO ""Role_Permission"" VALUES (@RoleId, @PermissionId);";
        return this._connection.QuerySingle<RolePermission>(query, new { RoleId = rolePermission.RoleId, PermissionId = rolePermission.PermissionId });
    }

    public bool Delete(int id)
    {
        const string query = @"DELETE FROM ""Role_Permission"" WHERE ""role_id"" = @RoleId;";
        int affectedRows = this._connection.Execute(query, new { RoleId = id });
        return affectedRows > 0;
    }
}

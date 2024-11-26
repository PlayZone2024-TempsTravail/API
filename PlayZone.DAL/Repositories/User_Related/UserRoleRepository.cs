using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.DAL.Repositories.User_Related;

public class UserRoleRepository : IUserRoleRepository
{
    // public IEnumerable<UserRole> GetAll()
    // {
    //     const string query = @"
    //         SELECT
    //             ""role_id"" AS ""RoleId"",
    //             ""user_id"" AS ""UserId""
    //         FROM ""User_Role"";
    //     ";
    //     return this._connection.Query<RolePermission>(query);
    // }

    public IEnumerable<UserRole> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserRole> GetByUser(int idRole)
    {
        throw new NotImplementedException();
    }

    public int Create(UserRole userRole)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int roleId, int userId)
    {
        throw new NotImplementedException();
    }
}

using PlayZone.BLL.Models.User_Related;
using Entities = PlayZone.DAL.Entities.User_Related;

namespace PlayZone.BLL.Mappers.User_Related;

public static class UserRoleMapper
{
    public static Entities.UserRole ToEntity(this UserRole ur)
    {
        return new Entities.UserRole
        {
            RoleId = ur.RoleId,
            UserId = ur.UserId
        };
    }

    public static UserRole ToModel(this Entities.UserRole ur)
    {
        return new UserRole
        {
            RoleId = ur.RoleId,
            UserId = ur.UserId
        };
    }
}

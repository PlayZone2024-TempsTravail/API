using PlayZone.API.DTOs.User_Related;
using Models = PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Mappers.User_Related;

public static class UserRoleMapper
{
    public static Models.UserRole ToModel(this UserRoleDTO ur)
    {
        return new Models.UserRole
        {
            RoleId = ur.RoleId,
            UserId = ur.UserId,
            RoleName = ur.RoleName
        };
    }

    public static UserRoleDTO ToDTO(this Models.UserRole ur)
    {
        return new UserRoleDTO
        {
            RoleId = ur.RoleId,
            UserId = ur.UserId,
            RoleName = ur.RoleName
        };
    }

    public static Models.UserRole ToModel(this UserRoleCreateDTO ur)
    {
        return new Models.UserRole
        {
            RoleId = ur.RoleId,
            UserId = ur.UserId
        };
    }

}

using Entities = PlayZone.DAL.Entities.User_Related;
using PlayZone.BLL.Models.User_Related;

namespace PlayZone.BLL.Mappers.User_Related;

public static class RolePermissionMapper
{
    public static RolePermission ToModel(this Entities.RolePermission rolePermission)
    {
        return new RolePermission
        {
            RoleId = rolePermission.RoleId,
            PermissionId = rolePermission.PermissionId
        };
    }

    public static Entities.RolePermission ToEntity(this RolePermission rolePermission)
    {
        return new Entities.RolePermission
        {
            RoleId = rolePermission.RoleId,
            PermissionId = rolePermission.PermissionId
        };
    }
}

using PlayZone.API.DTOs.User_Related;
using PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Mappers.User_Related;

public static class RolePermissionMapper
{
    public static RolePermission ToModel(this RolePermissionFormDTO rolePermission)
    {
        return new RolePermission
        {
            RoleId = rolePermission.RoleId,
            PermissionId = rolePermission.PermissionId
        };
    }
}

using PlayZone.API.DTO;
using PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Mappers;

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

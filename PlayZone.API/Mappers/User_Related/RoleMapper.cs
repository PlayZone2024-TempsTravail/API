using PlayZone.API.DTOs.User_Related;
using PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Mappers.User_Related;

public static class RoleMapper
{
    public static Role ToModel(this RoleDTO roleDTO)
    {
        return new Role
        {
            IdRole = roleDTO.IdRole,
            Name = roleDTO.Name
        };
    }
}

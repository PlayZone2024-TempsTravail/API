using PlayZone.API.DTOs.User_Related;
using PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Mappers.User_Related;

public static class RoleMapper
{
    public static Role ToModel(this RoleDTO roleDto)
    {
        return new Role
        {
            IdRole = roleDto.IdRole,
            Name = roleDto.Name,
            IsRemovable = roleDto.IsRemovable,
            IsVisible = roleDto.IsVisible
        };
    }

    public static Role ToModel(this RoleCreateDTO roleCreateDto)
    {
        return new Role
        {
            Name = roleCreateDto.Name
        };
    }

    public static RoleDTO ToDTO(this Role role)
    {
        return new RoleDTO
        {
            IdRole = role.IdRole,
            Name = role.Name,
            IsRemovable = role.IsRemovable,
            IsVisible = role.IsVisible
        };
    }
}

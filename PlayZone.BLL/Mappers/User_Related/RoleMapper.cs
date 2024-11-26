using Entities = PlayZone.DAL.Entities.User_Related;
using PlayZone.BLL.Models.User_Related;

namespace PlayZone.BLL.Mappers.User_Related;

public static class RoleMapper
{
    public static Role ToModel(this Entities.Role role)
    {
        return new Role
        {
            IdRole = role.IdRole,
            Name = role.Name
        };
    }

    public static Entities.Role ToEntity(this Role role)
    {
        return new Entities.Role
        {
            IdRole = role.IdRole,
            Name = role.Name
        };
    }
}

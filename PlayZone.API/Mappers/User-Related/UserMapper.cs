using PlayZone.API.DTOs.User_Related;
using Model = PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Mappers.User_Related;

public static class UserMapper
{
    public static Model.User ToModel(this UserCreateFormDTO user)
    {
        return new Model.User
        {
            RoleId = user.RoleId,
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            Password = user.Password,
            IsActive = user.IsActive,
            HeuresAnnuellesPrestables = user.HeuresAnnuellesPrestables,
            VA = user.VA,
            VAEX = user.VAEX,
            RC = user.RC,
        };
    }

    public static UserDTO ToDTO(this User user)
    {
        return new UserDTO
        {
            RoleId = user.RoleId,
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            Password = user.Password,
            IsActive = user.IsActive,
            HeuresAnnuellesPrestables = user.HeuresAnnuellesPrestables,
            VA = user.VA,
            VAEX = user.VAEX,
            RC = user.RC,
        };
    }
}

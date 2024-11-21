using PlayZone.API.DTOs.User_Related;
using Models = PlayZone.BLL.Models.User_Related;


namespace PlayZone.API.Mappers.User_Related;

public static class UserMapper
{
    public static UserDTO ToDTO(this Models.User user)
    {
        return new UserDTO
        {
            IdUser = user.IdUser,
            RoleId = user.RoleId,
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            //Password = user.Password,
            IsActive = user.IsActive,
            HeuresAnnuellesPrestables = user.HeuresAnnuellesPrestables,
            VA = user.VA,
            VAEX = user.VAEX,
            RC = user.RC,
        };
    }

    public static Models.User ToModels(this UserCreateFormDTO user)
    {
        return new Models.User
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

    public static Models.User ToModels(this UserLoginFormDTO user)
    {
        return new Models.User
        {
            Email = user.Email,
            Password = user.Password,
        };
    }

    public static Models.User ToModels(this UserDTO user)
    {
        return new Models.User
        {
            IdUser = user.IdUser,
            RoleId = user.RoleId,
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            //Password = user.Password,
            IsActive = user.IsActive,
            HeuresAnnuellesPrestables = user.HeuresAnnuellesPrestables,
            VA = user.VA,
            VAEX = user.VAEX,
            RC = user.RC,
        };
    }
}

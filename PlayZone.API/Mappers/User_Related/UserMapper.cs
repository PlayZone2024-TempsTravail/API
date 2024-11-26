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
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            //Password = user.Password,
            IsActive = user.IsActive,
        };
    }

    public static Models.User ToModels(this UserCreateFormDTO user)
    {
        return new Models.User
        {
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            Password = user.Password,
            IsActive = user.IsActive,
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
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            //Password = user.Password,
            IsActive = user.IsActive,
        };
    }

    public static UserLoginDTO ToLoginDTO(this Models.User user)
    {
        return new UserLoginDTO
        {
            IdUser = user.IdUser,
            Email = user.Email,
            Nom = user.Nom,
            Prenom = user.Prenom,
        };
    }
}

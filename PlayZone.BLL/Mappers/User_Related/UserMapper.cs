using PlayZone.BLL.Models.User_Related;
using Entities = PlayZone.DAL.Entities.User_Related;

namespace PlayZone.BLL.Mappers.User_Related;

public static class UserMapper
{
    public static Entities.User ToEntities(this User user)
    {
        return new Entities.User
        {
            IdUser = user.IdUser,
            IsActive = user.IsActive,
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            Password = user.Password,
        };
    }

    public static User ToModels(this Entities.User user)
    {
        return new User
        {
            IdUser = user.IdUser,
            IsActive = user.IsActive,
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            Password = user.Password,
        };
    }
}

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
            RoleId = user.RoleId,
            IsActive = user.IsActive,
            Nom = user.Nom,
            Prenom = user.Prenom,
            HeuresAnnuellesPrestables = user.HeuresAnnuellesPrestables,
            Email = user.Email,
            Password = user.Password,
            VA = user.VA,
            VAEX = user.VAEX,
            RC = user.RC
        };
    }

    public static User ToModels(this Entities.User user)
    {
        return new User
        {
            IdUser = user.IdUser,
            RoleId = user.RoleId,
            IsActive = user.IsActive,
            Nom = user.Nom,
            Prenom = user.Prenom,
            HeuresAnnuellesPrestables = user.HeuresAnnuellesPrestables,
            Email = user.Email,
            Password = user.Password,
            VA = user.VA,
            VAEX = user.VAEX,
            RC = user.RC
        };
    }
}

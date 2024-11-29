using PlayZone.BLL.Models.User_Related;
using Entities = PlayZone.DAL.Entities.User_Related;

namespace PlayZone.BLL.Mappers.User_Related;

public static class UserSalaireMapper
{
    public static Entities.UserSalaire ToEntity(this UserSalaire userSalaire)
    {
        return new Entities.UserSalaire
        {
            IdUserSalaire = userSalaire.IdUserSalaire,
            UserId = userSalaire.UserId,
            Date = userSalaire.Date,
            Regime = userSalaire.Regime,
            Montant = userSalaire.Montant
        };
    }

    public static UserSalaire ToModel(this Entities.UserSalaire userSalaire)
    {
        return new UserSalaire
        {
            IdUserSalaire = userSalaire.IdUserSalaire,
            UserId = userSalaire.UserId,
            Date = userSalaire.Date,
            Regime = userSalaire.Regime,
            Montant = userSalaire.Montant
        };
    }
}

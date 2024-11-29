using PlayZone.API.DTOs.User_Related;
using Models = PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Mappers.User_Related;

public static class UserSalaireMapper
{
    public static UserSalaireDTO ToDTO(this Models.UserSalaire userSalaire)
    {
        return new UserSalaireDTO
        {
            IdUserSalaire = userSalaire.IdUserSalaire,
            UserId = userSalaire.UserId,
            Date = userSalaire.Date,
            Regime = userSalaire.Regime,
            Montant = userSalaire.Montant
        };
    }

    public static Models.UserSalaire ToModel(this UserSalaireDTO userSalaire)
    {
        return new Models.UserSalaire
        {
            IdUserSalaire = userSalaire.IdUserSalaire,
            UserId = userSalaire.UserId,
            Date = userSalaire.Date,
            Regime = userSalaire.Regime,
            Montant = userSalaire.Montant
        };
    }

    public static Models.UserSalaire ToModel(this UserSalaireCreateDTO userSalaire)
    {
        return new Models.UserSalaire
        {
            UserId = userSalaire.UserId,
            Date = userSalaire.Date,
            Regime = userSalaire.Regime,
            Montant = userSalaire.Montant
        };
    }
}

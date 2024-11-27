using PlayZone.API.DTOs.Budget_Related;
using Models = PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Mappers.Budget_Related;

public static class RentreeMapper
{
    public static RentreeDTO ToDTO(this Models.Rentree rentree)
    {
        return new RentreeDTO
        {
            IdRentree = rentree.IdRentree,
            IdLibele = rentree.IdLibele,
            IdProject = rentree.IdProject,
            IdOrganisme = rentree.IdOrganisme,
            Montant = rentree.Montant,
            DateFacturation = rentree.DateFacturation,
            Motif = rentree.Motif,
        };
    }


    public static Models.Rentree ToModel(this RentreeDTO rentree)
    {
        return new Models.Rentree
        {
            IdRentree = rentree.IdRentree,
            IdLibele = rentree.IdLibele,
            IdProject = rentree.IdProject,
            IdOrganisme = rentree.IdOrganisme,
            Montant = rentree.Montant,
            DateFacturation = rentree.DateFacturation,
            Motif = rentree.Motif,
        };
    }

    public static Models.Rentree ToModel(this RentreeCreateFormDTO rentree)
    {
        return new Models.Rentree
        {
            IdLibele = rentree.IdLibele,
            IdProject = rentree.IdProject,
            IdOrganisme = rentree.IdOrganisme,
            Montant = rentree.Montant,
            DateFacturation = rentree.DateFacturation,
            Motif = rentree.Motif,
        };
    }

    public static Models.Rentree ToModel(this RentreeUpdateFormDTO rentree)
    {
        return new Models.Rentree
        {
            IdLibele = rentree.IdLibele,
            IdProject = rentree.IdProject,
            IdOrganisme = rentree.IdOrganisme,
            Montant = rentree.Montant,
            DateFacturation = rentree.DateFacturation,
            Motif = rentree.Motif,
        };
    }
}

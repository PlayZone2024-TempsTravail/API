using PlayZone.API.DTOs.Budget_Related;
using Model = PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Mappers.Budget_Related;

public static class RentreeMapper
{
    public static RentreeDTO ToDTO(this Model.Rentree rentree)
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


    public static Model.Rentree ToModel(this RentreeDTO rentree)
    {
        return new Model.Rentree
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

    public static Model.Rentree ToModels(this RentreeCreateFormDTO rentree)
    {
        return new Model.Rentree
        {
            IdLibele = rentree.IdLibele,
            IdProject = rentree.IdProject,
            IdOrganisme = rentree.IdOrganisme,
            Montant = rentree.Montant,
            DateFacturation = rentree.DateFacturation,
            Motif = rentree.Motif,
        };
    }

    public static Model.Rentree ToModels(this RentreeUpdateFormDTO rentree)
    {
        return new Model.Rentree
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

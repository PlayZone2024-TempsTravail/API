using System.Reflection.Metadata;
using PlayZone.BLL.Models.Budget_Related;
using Entities = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class RentreeMapper
{
    public static Entities.Rentree ToEntity(this Rentree rentree)
    {
        return new Entities.Rentree
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

    public static Rentree ToModel(this Entities.Rentree rentree)
    {
        return new Rentree
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
}

using System.Reflection.Metadata;
using PlayZone.BLL.Models.Budget_Related;
using Entity = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class RentreeMapper
{
    public static Entity.Rentree ToEntity(this Rentree rentree)
    {
        return new Entity.Rentree
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

    public static Rentree ToModel(this Entity.Rentree rentree)
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

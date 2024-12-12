using PlayZone.BLL.Models.Budget_Related;
using Entities = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class DepenseMapper
{
    public static Entities.Depense ToEntity(this Depense  depense)
    {
        return new Entities.Depense
        {
            IdDepense = depense.IdDepense,
            LibeleId = depense.LibeleId,
            ProjectId = depense.ProjectId,
            OrganismeId = depense.OrganismeId,
            Montant = depense.Montant,
            DateIntervention = depense.DateIntervention,
            DateFacturation = depense.DateFacturation,
            Motif = depense.Motif
        };
    }

    public static Depense ToModel(this Entities.Depense depense)
    {
        return new Depense
        {
            IdDepense = depense.IdDepense,
            LibeleId = depense.LibeleId,
            ProjectId = depense.ProjectId,
            OrganismeId = depense.OrganismeId,
            Montant = depense.Montant,
            DateIntervention = depense.DateIntervention,
            DateFacturation = depense.DateFacturation,
            Motif = depense.Motif
        };
    }
}

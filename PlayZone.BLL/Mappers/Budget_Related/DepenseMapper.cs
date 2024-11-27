using PlayZone.DAL.Entities.Budget_Related;
using Entities = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class DepenseMapper
{
    public static Entities.Depense ToEntity(this Depense  depense)
    {
        return new Entities.Depense
        {
            IdDepense = model.IdDepense,
            LibeleId = model.LibeleId,
            ProjectId = model.ProjectId,
            OrganismeId = model.OrganismeId,
            Montant = model.Montant,
            DateIntervention = model.DateIntervention,
            DateFacturation = model.DateFacturation,
            motif = model.motif
        };
    }

    public static Depense ToModel(this Entities.Depense depense)
    {
        return new Depense
        {
            IdDepense = entity.IdDepense,
            LibeleId = entity.LibeleId,
            ProjectId = entity.ProjectId,
            OrganismeId = entity.OrganismeId,
            Montant = entity.Montant,
            DateIntervention = entity.DateIntervention,
            DateFacturation = entity.DateFacturation,
            motif = entity.motif
        };
    }
}

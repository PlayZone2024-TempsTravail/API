using PlayZone.API.DTOs.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
namespace PlayZone.API.Mappers.Budget_Related;


public static class DepenseMapper
{
    public static DepenseDTO ToDTO(this DepenseDTO depense)
    {
        return new DepenseDTO
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

    public static Depense ToModel(this Depense depense)
    {
        return new Depense
        {
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

using PlayZone.API.DTOs.Budget_Related;
using PlayZone.DAL.Entities.Budget_Related;
using Models = PlayZone.BLL.Models.Budget_Related;
namespace PlayZone.API.Mappers.Budget_Related;


public static class DepenseMapper
{
    public static DepenseDTO ToDTO(this Models.Depense depense)
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

    public static Models.Depense ToModel(this CreateDepenseDTO depense)
    {
        return new Models.Depense
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

    public static Models.Depense ToModel(this UpdateDepenseDTO depense)
    {
        return new Models.Depense
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

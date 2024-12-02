using PlayZone.API.DTOs.Budget_Related;
using Model = PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Mappers.Budget_Related;

public static class ProjectMapper
{
    public static ProjectDTO ToDTO(this Model.Project project)
    {
        return new ProjectDTO
        {
            IdProject = project.IdProject,
            IsActive = project.IsActive,
            Name = project.Name,
            OrganismeId = project.OrganismeId,
            OrganismeName = project.OrganismeName,
            Color = project.Color,
            MontantBudget = project.MontantBudget,
            DateDebutProjet = project.DateDebutProjet,
            DateFinProjet = project.DateFinProjet,
            ChargeDeProjetId = project.ChargeDeProjetId,
            ChargeDeProjetName = project.ChargeDeProjetName,
            PrevisionDepenseActuelle = project.PrevisionDepenseActuelle,
            DepenseReelActuelle = project.DepenseReelActuelle
        };

    }

    public static Model.Project ToModel(this ProjectDTO project)
    {
        return new Model.Project
        {
            Name = project.Name,
            IdProject = project.IdProject,
            DateDebutProjet = project.DateDebutProjet,
            DateFinProjet = project.DateFinProjet,
            Color = project.Color,
            OrganismeId = project.OrganismeId,
            ChargeDeProjetId = project.ChargeDeProjetId,
            MontantBudget = project.MontantBudget,
            IsActive = project.IsActive
        };
    }

    public static Model.Project ToModel(this ProjectUpdateDTO project)
    {
        return new Model.Project
        {
            Name = project.Name,
            DateDebutProjet = project.DateDebutProjet,
            DateFinProjet = project.DateFinProjet,
            Color = project.Color,
            OrganismeId = project.OrganismeId,
            ChargeDeProjetId = project.ChargerDeProjetId,
            MontantBudget = project.MontantBudget,
            IsActive = project.IsActive
        };
    }

    public static Model.Project ToModel(this ProjectCreateDTO project)
    {
        return new Model.Project
        {
            Name = project.Name,
            DateDebutProjet = project.DateDebutProjet,
            DateFinProjet = project.DateFinProjet,
            Color = project.Color,
            OrganismeId = project.OrganismeId,
            ChargeDeProjetId = project.ChargerDeProjetId,
            MontantBudget = project.MontantBudget,
            IsActive = project.IsActive
        };
    }
    public static Model.Project ToModel(this ProjectDeleteDTO project)
    {
        return new Model.Project
        {
            IsActive = project.IsActive
        };
    }

}

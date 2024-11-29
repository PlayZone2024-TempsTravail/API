using PlayZone.API.DTOs.Budget_Related;
using Model = PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Mappers.Budget_Related;

public static class ProjectMapper
{
    public static ProjectDTO ToDTO(this Model.Project project)
    {
        return new ProjectDTO
        {
            Name = project.Name,
            IdProject = project.IdProject,
            DateDebutProjet = project.DateDebutProjet,
            DateFinProjet = project.DateFinProjet,
            Color = project.Color,
            OrganismeId = project.OrganismeId,
            ChargerDeProjetId = project.ChargerDeProjetId,
            MontantBudget = project.MontantBudget,
            IsActive = project.IsActive
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
            ChargerDeProjetId = project.ChargerDeProjetId,
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
            ChargerDeProjetId = project.ChargerDeProjetId,
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
            ChargerDeProjetId = project.ChargerDeProjetId,
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

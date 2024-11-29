using PlayZone.BLL.Models.Budget_Related;
using Entities = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class ProjectMapper
{
    public static Entities.Project ToEntity(this Project project)
    {
        return new Entities.Project
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

    public static Project ToModel(this Entities.Project project)
    {
        return new Project
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

}

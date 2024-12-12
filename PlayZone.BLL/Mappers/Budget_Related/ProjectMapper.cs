using PlayZone.BLL.Models.Budget_Related;
using Entities = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class ProjectMapper
{
    public static Entities.Project ToEntity(this Project project)
    {
        return new Entities.Project
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

    public static Project ToModel(this Entities.Project project)
    {
        return new Project
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

    public static ProjectShort ToModel(this Entities.ProjectShort entity)
    {
        return new ProjectShort
        {
            IdProject = entity.IdProject,
            IsActive = entity.IsActive,
            Name = entity.Name
        };
    }

}

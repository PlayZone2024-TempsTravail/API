using ProjectRapportEntity = PlayZone.DAL.Entities.Rapport_Related.ProjectRapport;

using ProjectRapportModel = PlayZone.BLL.Models.Rapport_Related.ProjectRapport;

namespace PlayZone.BLL.Mappers.Rapport_Related;

public static class ProjectRapportMapper
{
    public static ProjectRapportEntity ToEntity(this ProjectRapportModel model)
    {
        return new ProjectRapportEntity
        {
            DateStart = model.DateStart,
            DateEnd = model.DateEnd,
            Projects = model.Projects,
            Libelles = model.Libelles
        };
    }


}

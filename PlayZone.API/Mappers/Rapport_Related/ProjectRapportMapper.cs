using PlayZone.API.DTOs.Rapport_Related;
using Models = PlayZone.BLL.Models.Rapport_Related;

namespace PlayZone.API.Mappers.Rapport_Related;

public static class ProjectRapportMapper
{
    public static Models.ProjectRapport ToModel(this ProjectRapportDTO dto)
    {
        return new Models.ProjectRapport
        {
            DateStart = dto.DateStart,
            DateEnd = dto.DateEnd,
            Projects = dto.Projects,
            Libelles = dto.Libelles
        };
    }
}

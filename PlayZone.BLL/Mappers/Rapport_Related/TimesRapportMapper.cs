using TimesRapportModel = PlayZone.BLL.Models.Rapport_Related.TimesRapport;
using TimesRapportEntity = PlayZone.DAL.Entities.Rapport_Related.TimesProject;
using TimesRapportRazor = PlayZone.Razor.Models.TimesRapport;

namespace PlayZone.BLL.Mappers.Rapport_Related;

public static class TimesRapportMapper
{
    public static TimesRapportModel ToModel(this TimesRapportEntity entity)
    {
        return new TimesRapportModel
        {
            ProjectId = entity.ProjectId,
            ProjectName = entity.ProjectName,
            TotalDays = entity.TotalDays
        };
    }

    public static TimesRapportRazor ToRazor(this TimesRapportModel timesRapport)
    {
        return new TimesRapportRazor
        {
            ProjectId = timesRapport.ProjectId,
            ProjectName = timesRapport.ProjectName,
            TotalDays = timesRapport.TotalDays
        };
    }
}

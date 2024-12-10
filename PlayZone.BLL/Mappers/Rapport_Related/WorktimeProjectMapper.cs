using Entities = PlayZone.DAL.Entities.Rapport_Related;
using PlayZone.BLL.Models.Rapport_Related;
using PlayZone.Razor.Models;
using TimesRapport = PlayZone.Razor.Models.TimesRapport;


namespace PlayZone.BLL.Mappers.Rapport_Related;

public static class WorktimeProjectMapper
{
    public static Models.Rapport_Related.TimesRapport ToModel(this Entities.WorktimeProject entity)
    {
        return new Models.Rapport_Related.TimesRapport
        {
            ProjectId = entity.ProjectId,
            ProjectName = entity.ProjectName,
            TotalDays = entity.TotalDays
        };
    }

    public static TimesRapport ToRazor(this Models.Rapport_Related.TimesRapport timesRapport)
    {
        return new TimesRapport
        {
            ProjectId = timesRapport.ProjectId,
            ProjectName = timesRapport.ProjectName,
            TotalDays = timesRapport.TotalDays
        };
    }
}

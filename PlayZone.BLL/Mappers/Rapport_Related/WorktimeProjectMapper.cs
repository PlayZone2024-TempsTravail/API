using Entities = PlayZone.DAL.Entities.Rapport_Related;
using PlayZone.BLL.Models.Rapport_Related;
using PlayZone.Razor.Models;


namespace PlayZone.BLL.Mappers.Rapport_Related;

public static class WorktimeProjectMapper
{
    public static WorktimeProject ToModel(this Entities.WorktimeProject entity)
    {
        return new WorktimeProject
        {
            ProjectId = entity.ProjectId,
            ProjectName = entity.ProjectName,
            TotalDays = entity.TotalDays
        };
    }

    public static TotalDaysByProjectModel ToRazor(this WorktimeProject worktimeProject)
    {
        return new TotalDaysByProjectModel
        {
            ProjectId = worktimeProject.ProjectId,
            ProjectName = worktimeProject.ProjectName,
            TotalDays = worktimeProject.TotalDays
        };
    }
}

using PlayZone.BLL.Models.Worktime_Related;
using Entities = PlayZone.DAL.Entities.Worktime_Related;

namespace PlayZone.BLL.Mappers.Worktime_Related;

public static class WorktimeMapper
{
    public static Entities.Worktime ToEntities(this Worktime worktime)
    {
        return new Entities.Worktime
        {
            IdWorktime = worktime.IdWorktime,
            StartTime = worktime.StartTime,
            EndTime = worktime.EndTime,
            IsOnSite = worktime.IsOnSite,
            WorktimeCategoryId = worktime.WorktimeCategoryId,
            ProjectId = worktime.ProjectId,
            UserId = worktime.UserId
        };
    }

    public static Worktime ToModels(this Entities.Worktime worktime)
    {
        return new Worktime
        {
            IdWorktime = worktime.IdWorktime,
            StartTime = worktime.StartTime,
            EndTime = worktime.EndTime,
            IsOnSite = worktime.IsOnSite,
            WorktimeCategoryId = worktime.WorktimeCategoryId,
            ProjectId = worktime.ProjectId,
            UserId = worktime.UserId
        };
    }
}

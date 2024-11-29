using PlayZone.BLL.Models.Worktime_Related;
using Entities = PlayZone.DAL.Entities.Worktime_Related;

namespace PlayZone.BLL.Mappers.Worktime_Related;

public static class WorktimeMapper
{
    public static Entities.Worktime ToEntity(this Worktime worktime)
    {
        return new Entities.Worktime
        {
            IdWorktime = worktime.IdWorktime,
            Start = worktime.Start,
            End = worktime.End,
            IsOnSite = worktime.IsOnSite,
            CategoryId = worktime.CategoryId,
            ProjectId = worktime.ProjectId,
            UserId = worktime.UserId
        };
    }

    public static Worktime ToModel(this Entities.Worktime worktime)
    {
        return new Worktime
        {
            IdWorktime = worktime.IdWorktime,
            Start = worktime.Start,
            End = worktime.End,
            IsOnSite = worktime.IsOnSite,
            CategoryId = worktime.CategoryId,
            ProjectId = worktime.ProjectId,
            UserId = worktime.UserId
        };
    }
}

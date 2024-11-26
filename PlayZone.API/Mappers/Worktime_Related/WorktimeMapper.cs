using PlayZone.API.DTOs.Worktime_Related;
using Models = PlayZone.BLL.Models.Worktime_Related;

namespace PlayZone.API.Mappers.Worktime_Related;

public static class WorktimeMapper
{
    public static WorktimeDTO ToDTO(this Models.Worktime worktime)
    {
        return new WorktimeDTO
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

    public static Models.Worktime ToModel(this WorktimeDTO worktime)
    {
        return new Models.Worktime
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

    public static Models.Worktime ToModel(this WorktimeCreateFormDTO worktime)
    {
        return new Models.Worktime
        {
            Start = worktime.Start,
            End = worktime.End,
            IsOnSite = worktime.IsOnSite,
            CategoryId = worktime.CategoryId,
            ProjectId = worktime.ProjectId,
            UserId = worktime.UserId,
        };
    }

    public static Models.Worktime ToModel(this WorktimeUpdateFormDTO worktime)
    {
        return new Models.Worktime
        {
            Start = worktime.Start,
            End = worktime.End,
            IsOnSite = worktime.IsOnSite,
            CategoryId = worktime.CategoryId,
            ProjectId = worktime.ProjectId,
            UserId = worktime.UserId
        };

    }
}

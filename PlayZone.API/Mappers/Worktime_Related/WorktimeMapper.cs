using PlayZone.API.DTOs.Worktime_Related;
using Models = PlayZone.BLL.Models.Worktime_Related;

namespace PlayZone.API.Mappers.Worktime_Related;

public static class WorktimeMapper
{
    public static WorktimeDto ToDto(this Models.Worktime worktime)
    {
        return new WorktimeDto
        {
            IdWorktime = worktime.IdWorktime,
            Start = worktime.Start,
            End = worktime.End,
            CategoryId = worktime.CategoryId,
            ProjectId = worktime.ProjectId,
            UserId = worktime.UserId
        };
    }

    public static Models.Worktime ToModels(this WorktimeDto worktime)
    {
        return new Models.Worktime
        {
            IdWorktime = worktime.IdWorktime,
            Start = worktime.Start,
            End = worktime.End,
            CategoryId = worktime.CategoryId,
            ProjectId = worktime.ProjectId,
            UserId = worktime.UserId
        };
    }

    public static Models.Worktime ToModels(this WorktimeUpdateFormDto worktime)
    {
        return new Models.Worktime
        {
            Start = worktime.Start,
            End = worktime.End,
            CategoryId = worktime.CategoryId,
            ProjectId = worktime.ProjectId,
            UserId = worktime.UserId
        };

    }
}

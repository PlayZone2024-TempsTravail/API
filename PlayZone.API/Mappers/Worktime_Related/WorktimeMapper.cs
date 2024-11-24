using PlayZone.API.DTOs.Worktime_Related;
using Models = PlayZone.BLL.Models.Worktime_Related;

namespace PlayZone.API.Mappers.Worktime_Related;

public static class WorktimeMapper
{
    public static WorktimeDTO ToDto(this Models.Worktime worktime)
    {
        return new WorktimeDTO
        {
            IdWorktime = worktime.IdWorktime,
            Start = worktime.Start,
            End = worktime.End,
            CategoryId = worktime.CategoryId,
            ProjectId = worktime.ProjectId
        };
    }

    public static Models.Worktime ToModels(this WorktimeDTO worktime)
    {
        return new Models.Worktime
        {
            IdWorktime = worktime.IdWorktime,
            Start = worktime.Start,
            End = worktime.End,
            CategoryId = worktime.CategoryId,
            ProjectId = worktime.ProjectId
        };
    }
}

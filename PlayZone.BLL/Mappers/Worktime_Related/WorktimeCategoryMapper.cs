using PlayZone.BLL.Models.Worktime_Related;
using Entities = PlayZone.DAL.Entities.Worktime_Related;

namespace PlayZone.BLL.Mappers.Worktime_Related;

public static class WorktimeCategoryMapper
{
    public static Entities.WorktimeCategory ToEntity(this WorktimeCategory worktimeCategory)
    {
        return new Entities.WorktimeCategory
        {
            IdWorktimeCategory = worktimeCategory.IdWorktimeCategory,
            IsActive = worktimeCategory.IsActive,
            Abreviation = worktimeCategory.Abreviation,
            Name = worktimeCategory.Name,
            Color = worktimeCategory.Color
        };
    }

    public static WorktimeCategory ToModel(this Entities.WorktimeCategory worktimeCategory)
    {
        return new WorktimeCategory
        {
            IdWorktimeCategory = worktimeCategory.IdWorktimeCategory,
            IsActive = worktimeCategory.IsActive,
            Abreviation = worktimeCategory.Abreviation,
            Name = worktimeCategory.Name,
            Color = worktimeCategory.Color
        };
    }
}

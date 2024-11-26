using PlayZone.API.DTOs.Worktime_Related;
using Models = PlayZone.BLL.Models.Worktime_Related;

using PlayZone.API.DTOs.Worktime_Related;

namespace PlayZone.API.Mappers.Worktime_Related;

public static class WorktimeCategoryMapper
{
    public static WorktimeCategoryDTO ToDTO(this Models.WorktimeCategory worktimeCategory)
    {
        return new WorktimeCategoryDTO
        {
            IdWorktimeCategory = worktimeCategory.IdWorktimeCategory,
            IsActive = worktimeCategory.IsActive,
            Abreviation = worktimeCategory.Abreviation,
            Name = worktimeCategory.Name,
            Color = worktimeCategory.Color
        };
    }

    public static Models.WorktimeCategory ToModels(this WorktimeCategoryDTO worktimeCategory)
    {
        return new Models.WorktimeCategory
        {
            IdWorktimeCategory = worktimeCategory.IdWorktimeCategory,
            IsActive = worktimeCategory.IsActive,
            Abreviation = worktimeCategory.Abreviation,
            Name = worktimeCategory.Name,
            Color = worktimeCategory.Color
        };
    }

    public static Models.WorktimeCategory ToModels(this WorktimeCategoryUpdateFormDTO worktimeCategory)
    {
        return new Models.WorktimeCategory
        {
            IsActive = worktimeCategory.IsActive,
            Abreviation = worktimeCategory.Abreviation,
            Name = worktimeCategory.Name,
            Color = worktimeCategory.Color
        };
    }

    public static Models.WorktimeCategory ToModels(this WorktimeCategoryCreateFormDTO worktimeCategory)
    {
        return new Models.WorktimeCategory
        {
            IsActive = worktimeCategory.IsActive,
            Abreviation = worktimeCategory.Abreviation,
            Name = worktimeCategory.Name,
            Color = worktimeCategory.Color
        };
    }
}

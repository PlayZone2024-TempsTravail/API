namespace PlayZone.API.DTOs.Worktime_Related;

public class WorktimeCategoryDTO
{
    public string IdWorktimeCategory { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}

public class WorktimeCategoryUpdateFormDTO
{
    public string Name { get; set; }
    public string Color { get; set; }
}

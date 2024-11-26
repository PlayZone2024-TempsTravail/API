namespace PlayZone.API.DTOs.Worktime_Related;

public class WorktimeCategoryDTO
{
    public int IdWorktimeCategory { get; set; }
    public bool IsActive { get; set; }
    public string Abreviation { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}

public class WorktimeCategoryUpdateFormDTO
{
    public bool IsActive { get; set; }
    public string Abreviation { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}

public class WorktimeCategoryCreateFormDTO
{
    public bool IsActive { get; set; }
    public string Abreviation { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}

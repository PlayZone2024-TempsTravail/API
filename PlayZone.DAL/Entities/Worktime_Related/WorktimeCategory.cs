namespace PlayZone.DAL.Entities.Worktime_Related;

public class WorktimeCategory
{
    public int IdWorktimeCategory { get; set; }
    public bool IsActive { get; set; }
    public string Abreviation { get; set; }
    public required string Name { get; set; }
    public required string Color { get; set; }
}

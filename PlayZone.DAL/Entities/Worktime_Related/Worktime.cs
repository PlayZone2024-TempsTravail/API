namespace PlayZone.DAL.Entities.Worktime_Related;

public class Worktime
{
    public int IdWorktime { get; set; } // Primary key
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public required string WorktimeCategoryId { get; set; } //Foreign key
    public int? ProjectId { get; set; } //Foreign key
    public int UserId { get; set; } //Foreign key
}

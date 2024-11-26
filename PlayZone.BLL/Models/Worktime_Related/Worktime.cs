namespace PlayZone.BLL.Models.Worktime_Related;

public class Worktime
{
    public int IdWorktime { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsOnSite { get; set; }
    public required string WorktimeCategoryId { get; set; }
    public int? ProjectId { get; set; }
    public int UserId { get; set; }
}

namespace PlayZone.API.DTOs.Worktime_Related;

public class WorktimeDTO
{
    public int IdWorktime { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool IsOnSite { get; set; }
    public required string CategoryId { get; set; }
    public int? ProjectId { get; set; }
    public int UserId { get; set; }
}

public class WorktimeUpdateFormDto
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string CategoryId { get; set; }
    public int? ProjectId { get; set; }
    public int UserId { get; set; }
}

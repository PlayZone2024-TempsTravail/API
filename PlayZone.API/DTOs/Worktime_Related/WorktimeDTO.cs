using Microsoft.Build.Framework;

namespace PlayZone.API.DTOs.Worktime_Related;

public class WorktimeDTO
{
    public int IdWorktime { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool IsOnSite { get; set; }
    public int CategoryId { get; set; }
    public int? ProjectId { get; set; }
    public int UserId { get; set; }
}

public class WorktimeCreateFormDTO
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool IsOnSite { get; set; }
    public int CategoryId { get; set; }
    public int? ProjectId { get; set; }
    public int UserId { get; set; }
}

public class WorktimeUpdateFormDTO
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool IsOnSite { get; set; }
    public int CategoryId { get; set; }
    public int? ProjectId { get; set; }
    public int UserId { get; set; }
}

public class worktimeDeleteFormDTO
{
    [Required]
    public int idWorktime { get; set; }
}

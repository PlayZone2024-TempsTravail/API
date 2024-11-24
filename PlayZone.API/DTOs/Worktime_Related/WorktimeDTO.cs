using System.ComponentModel.DataAnnotations;
using PlayZone.BLL.Models.Worktime_Related;

namespace PlayZone.API.DTOs.Worktime_Related;

public class WorktimeDTO
{
    public int IdWorktime { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public required string CategoryId { get; set; }
    public int? ProjectId { get; set; }

    public Worktime ToModel()
    {
        return new Worktime
        {
            IdWorktime = this.IdWorktime,
            Start = this.Start,
            End = this.End,
            CategoryId = this.CategoryId,
            ProjectId = this.ProjectId
        };
    }
}

public class WorktimeCreateFormDto
{
    [Required]
    public DateTime Start { get; set; }
    [Required]
    public DateTime End { get; set; }
    [Required]
    public string CategoryId { get; set; }
    public int? ProjectId { get; set; }
}

public class WorktimeUpdateFormDto
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string CategoryId { get; set; }
    public int? ProjectId { get; set; }
}

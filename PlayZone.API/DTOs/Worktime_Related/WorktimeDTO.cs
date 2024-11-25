using System.ComponentModel.DataAnnotations;
using PlayZone.BLL.Models.Worktime_Related;

namespace PlayZone.API.DTOs.Worktime_Related;

public class WorktimeDto
{
    public int IdWorktime { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public required string CategoryId { get; set; }
    public int? ProjectId { get; set; }
    public int UserId { get; set; }

    public Worktime ToModel()
    {
        return new Worktime
        {
            IdWorktime = this.IdWorktime,
            Start = this.Start,
            End = this.End,
            CategoryId = this.CategoryId,
            ProjectId = this.ProjectId,
            UserId = this.UserId
        };
    }
}

public class WorktimeUpdateFormDto
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string CategoryId { get; set; }
    public int? ProjectId { get; set; }
    public int UserId { get; set; }
}

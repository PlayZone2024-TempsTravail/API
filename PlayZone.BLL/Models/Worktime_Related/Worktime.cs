namespace PlayZone.BLL.Models.Worktime_Related;

public class Worktime
{
    public int IdWorktime { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public required string CategoryId { get; set; }
    public int? ProjectId { get; set; }
}

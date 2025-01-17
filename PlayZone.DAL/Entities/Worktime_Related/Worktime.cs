﻿namespace PlayZone.DAL.Entities.Worktime_Related;

public class Worktime
{
    public int IdWorktime { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool IsOnSite { get; set; }
    public int CategoryId { get; set; }
    public int? ProjectId { get; set; }
    public int UserId { get; set; }
}

namespace PlayZone.API.DTOs.Worktime_Related;

public class CompteurAbsenceDTO
{
    public required string Category { get; set; }
    public int Counter { get; set; }
    public int Max { get; set; }
    public int Difference { get; set; }
}

public class CompteurProjetDTO
{
    public int projectId { get; set; }
    public string projectName { get; set; }
    public int Heures { get; set; }
}

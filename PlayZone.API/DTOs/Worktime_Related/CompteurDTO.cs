namespace PlayZone.API.DTOs.Worktime_Related;

public class CompteurAbsenceDTO
{
    public required string Category { get; set; }
    public decimal Max { get; set; }
    public decimal Counter { get; set; }

    public decimal Solde { get; set; }
}

public class CompteurProjetDTO
{
    public int projectId { get; set; }
    public string projectName { get; set; }
    public int Heures { get; set; }
}

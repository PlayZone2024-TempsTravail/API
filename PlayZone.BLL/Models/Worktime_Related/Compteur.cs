namespace PlayZone.BLL.Models.Worktime_Related;

public class CompteurAbsence
{
    public required string Category { get; set; }
    public int Counter { get; set; }
    public int Max { get; set; }
    public int Difference { get; set; }
}

public class CompteurProjet
{
    public int projectId { get; set; }
    public string projectName { get; set; }
    public int Heures { get; set; }
}

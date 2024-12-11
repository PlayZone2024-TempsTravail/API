namespace PlayZone.DAL.Entities.Rapport_Related;

public class ProjectRapport
{
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public IEnumerable<int> Projects { get; set; } = [];
    public IEnumerable<int> Libelles { get; set; } = [];
}

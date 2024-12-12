namespace PlayZone.Razor.Models;

public class ExtractProjectRapport
{
    public int ProjectId { get; set; }
    public int CategoryId { get; set; }
    public int LibelleId { get; set; }
    public string ProjectName { get; set; }
    public string CategoryName { get; set; }
    public string LibelleName { get; set; }
    public string Organisme { get; set; }
    public string Motif { get; set; }
    public DateTime Date { get; set; }
    public decimal Montant { get; set; }
}

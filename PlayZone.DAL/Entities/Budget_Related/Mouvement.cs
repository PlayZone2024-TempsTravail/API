namespace PlayZone.DAL.Entities.Budget_Related;

public class Mouvement
{
    public required string Category { get; set; }
    public required string Libele { get; set; }
    public required string Date { get; set; }
    public decimal Montant { get; set; }
}

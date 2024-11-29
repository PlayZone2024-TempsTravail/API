namespace PlayZone.DAL.Entities.Budget_Related;

public class PrevisionBudgetLibele
{
    public int IdPrevisionBudgetLibele { get; set; }
    public int IdProject { get; set; }
    public int IdLibele  { get; set; }
    public DateTime Date { get; set; }
    public string Motif { get; set; }
    public decimal? Montant { get; set; }
}

namespace PlayZone.DAL.Entities.Budget_Related;

public class PrevisionBudgetLibele
{
    public int IdPrevisionBudgetLibele { get; set; }
    public int IdProject { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int LibeleId { get; set; }
    public string LibeleName { get; set; }
    public DateTime Date { get; set; }
    public string Motif { get; set; }
    public decimal? Montant { get; set; }
}

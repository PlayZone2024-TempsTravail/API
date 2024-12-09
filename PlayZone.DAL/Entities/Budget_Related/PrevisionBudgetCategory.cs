namespace PlayZone.DAL.Entities.Budget_Related;

public class PrevisionBudgetCategory
{
    public int IdPrevisionBudgetCategory { get; set; }
    public int ProjectId { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public bool IsIncome { get; set; }
    public string Motif { get; set; }
    public DateTime Date { get; set; }
    public decimal Montant { get; set; }
}

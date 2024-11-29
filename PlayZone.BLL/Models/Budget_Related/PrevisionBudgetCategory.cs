namespace PlayZone.BLL.Models.Budget_Related;

public class PrevisionBudgetCategory
{
    public int idPrevisionBudgetCategory { get; set; }
    public int projectId { get; set; }
    public int categoryId { get; set; }
    public string motif { get; set; }
    public DateTime date { get; set; }
    public decimal montant { get; set; }
}

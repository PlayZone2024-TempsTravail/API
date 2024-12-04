namespace PlayZone.BLL.Models.Budget_Related;

public class TransactionResult
{
    public string Category { get; set; }
    public string Libele { get; set; }
    public string Organisme { get; set; }
    public string Motif { get; set; }
    public DateTime DateFacturation { get; set; }
    public decimal Montant { get; set; }
}

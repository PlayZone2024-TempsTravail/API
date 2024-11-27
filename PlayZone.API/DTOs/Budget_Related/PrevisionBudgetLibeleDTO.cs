namespace PlayZone.API.DTOs.Budget_Related;

public class PrevisionBudgetLibeleDTO
{
    public int IdPrevisionBudgetLibele { get; set; }
    public int IdProject { get; set; }
    public int IdLibele  { get; set; }
    public DateTime Date { get; set; }
    public string Motif { get; set; }
    public decimal? Montant { get; set; }
}

public class PrevisionBudgetLibeleCreateDTO
{
    public int IdProject { get; set; }
    public int IdLibele  { get; set; }
    public DateTime Date { get; set; }
    public string Motif { get; set; }
    public decimal? Montant { get; set; }
}

public class PrevisionBudgetLibeleUpdateDTO
{
    public int IdProject { get; set; }
    public int IdLibele  { get; set; }
    public DateTime Date { get; set; }
    public string Motif { get; set; }
    public decimal? Montant { get; set; }
}

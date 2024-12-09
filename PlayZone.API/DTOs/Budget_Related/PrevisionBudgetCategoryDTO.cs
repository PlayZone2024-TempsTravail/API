using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.Budget_Related;

public class PrevisionBudgetCategoryDTO
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

public class PrevisionBudgetCategoryCreateDTO
{
    [Required]
    public int projectId { get; set; }

    [Required]
    public int categoryId { get; set; }

    [Required]
    public string motif { get; set; }

    [Required]
    public DateTime date { get; set; }

    [Required]
    public decimal montant { get; set; }
}

public class PrevisionBudgetCategoryUpdateDTO
{
    public string motif { get; set; }

    public DateTime date { get; set; }

    public decimal montant { get; set; }
}

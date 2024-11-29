using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.Budget_Related;

public class PrevisionBudgetCategoryDTO
{
    public int idPrevisionBudgetCategory { get; set; }
    public int projectId { get; set; }
    public int categoryId { get; set; }
    public string motif { get; set; }
    public DateTime date { get; set; }
    public decimal montant { get; set; }
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

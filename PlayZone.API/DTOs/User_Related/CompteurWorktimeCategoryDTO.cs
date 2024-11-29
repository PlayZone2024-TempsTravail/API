using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;

public class CompteurWorktimeCategoryDTO
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public int WorktimeCategoryId { get; set; }
    public int Quantity { get; set; }
}

public class CompteurWorktimeCategoryUpdateDTO
{
    public int WorktimeCategoryId { get; set; }
    public int Quantity { get; set; }
}

public class CompteurWorktimeCategoryDeleteDTO
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public int WorktimeCategoryId { get; set; }
}

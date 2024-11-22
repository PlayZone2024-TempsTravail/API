using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.Worktime_Related;

public class worktimeDeleteFromDTO
{
    [Required]
    public int idWorktime { get; set; }
}

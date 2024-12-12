using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.Rapport_Related;

public class DateRapportDTO
{
    [Required]
    public DateTime start { get; set; }

    [Required]
    public DateTime end { get; set; }
}

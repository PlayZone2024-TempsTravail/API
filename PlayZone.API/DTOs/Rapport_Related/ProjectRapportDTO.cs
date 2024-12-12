using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.Rapport_Related;

public class ProjectRapportDTO
{
    [Required]
    public DateTime DateStart { get; set; }

    [Required]
    public DateTime DateEnd { get; set; }

    [Required]
    public IEnumerable<int> Projects { get; set; } = [];

    [Required]
    public IEnumerable<int> Libelles { get; set; } = [];
}

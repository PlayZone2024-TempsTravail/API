using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;

public class UserCreateFormDTO
{
    public int IdUser { get; set; }

    [Required]
    public string Nom { get; set; }

    [Required]
    public string Prenom { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string RoleId { get; set; }

    [Required]
    public int HeuresAnnuellesPrestables { get; set; }

    public int VA { get; set; }
    public int VAEX { get; set; }
    public int RC { get; set; }
}

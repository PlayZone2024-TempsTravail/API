using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;

public class UserDTO
{
    public int IdUser { get; set; }
    public int RoleId { get; set; }
    public string? Nom { get; set; }
    public string? Prenom { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public int HeuresAnnuellesPrestables { get; set; }
    public int VA { get; set; }
    public int VAEX { get; set; }
    public int RC { get; set; }
}

public class UserLoginFormDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}

public class UserCreateFormDTO
{
    public bool IsActive { get; set; }

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
    public int RoleId { get; set; }

    [Required]
    public int HeuresAnnuellesPrestables { get; set; }

    public int VA { get; set; }
    public int VAEX { get; set; }
    public int RC { get; set; }
}

public class UserLoginDTO
{
    public int IdUser { get; set; }
    public int RoleId { get; set; }
    public string Email { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
}

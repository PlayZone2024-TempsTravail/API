using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;

public class UserDTO
{
    public int RoleId { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public int HeuresAnnuellesPrestables { get; set; }
    public int VA { get; set; }
    public int VAEX { get; set; }
    public int RC { get; set; }
}

public class UserUpdateFormDTO
{
    public int RoleId { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    //public bool IsActive { get; set; }
    public int HeuresAnnuellesPrestables { get; set; }
}
  
public class UserCreateFormDTO
{
    public int IdUser { get; set; }

    public bool IsActive { get; set; } = true

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

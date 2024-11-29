using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;

public class RoleDTO
{
    public int IdRole { get; set; }
    public string Name { get; set; }
}

public class RoleCreateDTO
{
    [Required]
    public string Name { get; set; }
}

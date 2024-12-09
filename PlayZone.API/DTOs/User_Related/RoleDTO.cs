using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;

public class RoleDTO
{
    public int IdRole { get; set; }
    public string Name { get; set; }
    public bool IsRemovable { get; set; }
    public bool IsVisible { get; set; }
}

public class RoleCreateDTO
{
    [Required]
    public string Name { get; set; }
}

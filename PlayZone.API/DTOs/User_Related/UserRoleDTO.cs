using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;



public class UserRoleDTO
{
    public int RoleId { get; set; }
    public int UserId { get; set; }
    public string RoleName { get; set; }
}

public class UserRoleCreateDTO
{
    [Required]
    public int RoleId { get; set; }

    [Required]
    public int UserId { get; set; }
}

public class UserRoleDeleteDTO
{
    [Required]
    public int RoleId { get; set; }

    [Required]
    public int UserId { get; set; }
}

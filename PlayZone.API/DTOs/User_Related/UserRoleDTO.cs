using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;

public class UserRoleDTO
{
    [Required]
    public int RoleId { get; set; }

    [Required]
    public int UserId { get; set; }
}

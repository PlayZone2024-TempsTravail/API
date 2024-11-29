using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;

public class RolePermissionDTO
{
    [Required]
    public int RoleId { get; set; }

    [Required]
    public required string PermissionId { get; set; }
}

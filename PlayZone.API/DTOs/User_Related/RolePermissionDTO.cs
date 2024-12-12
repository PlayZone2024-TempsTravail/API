using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;

public class RolePermissionDTO
{
    [Required]
    public int RoleId { get; set; }

    [Required]
    public required string PermissionId { get; set; }
}

public class RolePermissionUpdateDTO
{
    public IEnumerable<RolePermissionDTO> add { get; set; }
    public IEnumerable<RolePermissionDTO> remove { get; set; }
}

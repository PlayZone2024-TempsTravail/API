namespace PlayZone.BLL.Models.User_Related;

public class UserRole
{
    public int RoleId { get; set; }
    public int UserId { get; set; }
    public string RoleName { get; set; } = String.Empty;
}

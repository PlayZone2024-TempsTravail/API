namespace PlayZone.BLL.Models.User_Related;

public class User
{
    public int IdUser { get; set; }
    public int RoleId { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

}

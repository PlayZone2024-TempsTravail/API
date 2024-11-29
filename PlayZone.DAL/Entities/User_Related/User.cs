namespace PlayZone.DAL.Entities.User_Related;

public class User
{
    public int IdUser { get; set; }
    public bool IsActive { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

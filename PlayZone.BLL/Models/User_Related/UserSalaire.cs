namespace PlayZone.BLL.Models.User_Related;

public class UserSalaire
{
    public int IdUserSalaire { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public int Regime { get; set; }
    public double Montant { get; set; }
}

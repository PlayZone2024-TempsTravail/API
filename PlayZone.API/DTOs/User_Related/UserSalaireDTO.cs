using System.ComponentModel.DataAnnotations;

namespace PlayZone.API.DTOs.User_Related;

public class UserSalaireDTO
{
    public int IdUserSalaire { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public int Regime { get; set; }
    public double Montant { get; set; }
}

public class UserSalaireCreateDTO
{
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    [Range(0, 100)]
    public int Regime { get; set; }
    public double Montant { get; set; }
}

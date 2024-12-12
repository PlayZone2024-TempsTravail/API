namespace PlayZone.API.DTOs.Budget_Related;

public class PreparedGraphicDTO
{
    public List<string> Date { get; set; } = new List<string>();
    public List<decimal> Prevision { get; set; } = new List<decimal>();
    public List<decimal> Reel { get; set; } = new List<decimal>();
}

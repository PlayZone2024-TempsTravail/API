namespace PlayZone.DAL.Entities.Budget_Related;

public class Rentree
{
    public int IdRentree { get; set; }
    public int IdLibele  { get; set; }
    public int IdProject { get; set; }
    public int IdOrganisme{ get; set; }
    public decimal? Montant { get; set; }
    public DateTime DateFacturation { get; set; }
    public string Motif { get; set; }
}

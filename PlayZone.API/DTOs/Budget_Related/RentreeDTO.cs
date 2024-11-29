namespace PlayZone.API.DTOs.Budget_Related;

public class RentreeDTO
{
    public int IdRentree { get; set; }
    public int IdLibele  { get; set; }
    public int IdProject { get; set; }
    public int IdOrganisme{ get; set; }
    public decimal? Montant { get; set; }
    public DateTime DateFacturation { get; set; }
    public string Motif { get; set; }
}

public class RentreeCreateFormDTO
{
    public int IdLibele  { get; set; }
    public int IdProject { get; set; }
    public int IdOrganisme{ get; set; }
    public decimal? Montant { get; set; }
    public DateTime DateFacturation { get; set; }
    public string Motif { get; set; }
}

public class RentreeUpdateFormDTO
{
    public int IdLibele  { get; set; }
    public int IdProject { get; set; }
    public int IdOrganisme{ get; set; }
    public decimal? Montant { get; set; }
    public DateTime DateFacturation { get; set; }
    public string Motif { get; set; }
}

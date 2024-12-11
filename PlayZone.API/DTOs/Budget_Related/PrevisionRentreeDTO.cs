namespace PlayZone.API.DTOs.Budget_Related;

public class PrevisionRentreeDTO
{
    public int IdPrevisionRentree { get; set; }
    public int ProjectId { get; set; }
    public int? OrganismeId { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int LibeleId { get; set; }
    public string LibeleName { get; set; }
    public DateTime Date { get; set; }
    public string Motif { get; set; }
    public double Montant { get; set; }
}

public class PrevisionRentreeCreateDTO
{
    public int ProjectId { get; set; }
    public int? OrganismeId { get; set; }
    public int LibeleId { get; set; }
    public DateTime Date { get; set; }
    public string Motif { get; set; }
    public double Montant { get; set; }
}

public class PrevisionRentreeUpdateDTO
{
    public int ProjectId { get; set; }
    public int? OrganismeId { get; set; }
    public int LibeleId { get; set; }
    public DateTime Date { get; set; }
    public string Motif { get; set; }
    public double Montant { get; set; }
}

public class PrevisionRentreeDeleteDTO
{
    public int IdPrevisionRentree { get; set; }
}

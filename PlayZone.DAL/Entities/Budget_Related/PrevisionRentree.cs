namespace PlayZone.DAL.Entities.Budget_Related;

public class PrevisionRentree
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

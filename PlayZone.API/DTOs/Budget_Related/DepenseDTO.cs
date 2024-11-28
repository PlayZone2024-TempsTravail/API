namespace PlayZone.API.DTOs.Budget_Related;

public class DepenseDTO
{
    public int IdDepense { get; set; }
    public int LibeleId { get; set; }
    public int ProjectId { get; set; }
    public int OrganismeId {get; set;}
    public decimal Montant { get; set; }
    public DateTime DateIntervention { get; set; }
    public DateTime DateFacturation { get; set; }
    public string Motif { get; set; }
}

public class CreateDepenseDTO
{
    public int LibeleId { get; set; }
    public int ProjectId { get; set; }
    public int OrganismeId {get; set;}
    public int Montant { get; set; }
    public DateTime DateIntervention { get; set; }
    public DateTime DateFacturation { get; set; }
    public string Motif { get; set; }

}
public class UpdateDepenseDTO
{
    public int LibeleId { get; set; }
    public int ProjectId { get; set; }
    public int OrganismeId {get; set;}
    public int Montant { get; set; }
    public DateTime DateIntervention { get; set; }
    public DateTime DateFacturation { get; set; }
    public string Motif { get; set; }
}

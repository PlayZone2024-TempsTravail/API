namespace PlayZone.BLL.Models.Budget_Related;

public class Project
{
    public int IdProject { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }
    public int OrganismeId { get; set; }
    public string OrganismeName { get; set; }
    public string Color { get; set; }
    public decimal MontantBudget { get; set; }
    public DateTime DateDebutProjet { get; set; }
    public DateTime DateFinProjet { get; set; }
    public int ChargeDeProjetId { get; set; }
    public string ChargeDeProjetName { get; set; }
    public decimal PrevisionDepenseActuelle { get; set; }
    public decimal DepenseReelActuelle { get; set; }
}

public class ProjectShort()
{
    public int IdProject { get; set; }
    public bool IsActive { get; set; }
    public required string Name { get; set; }
}

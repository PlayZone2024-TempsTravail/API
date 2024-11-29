namespace PlayZone.BLL.Models.Budget_Related;

public class Project
{
    public int IdProject { get; set; }
    public string Name { get; set; }

    public int OrganismeId { get; set; }

    public string Color { get; set; }
    public decimal MontantBudget { get; set; }
    public DateTime DateDebutProjet { get; set; }
    public DateTime DateFinProjet { get; set; }
    public DateTime DateDebutFormation { get; set; }
    public int ChargerDeProjetId { get; set; }
    public bool IsActive { get; set; }
}

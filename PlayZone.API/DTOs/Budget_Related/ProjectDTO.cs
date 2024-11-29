namespace PlayZone.API.DTOs.Budget_Related;

public class ProjectDTO
{
    public int IdProject { get; set; }
    public string Name { get; set; }
    public int OrganismeId { get; set; }
    public string Color { get; set; }
    public decimal MontantBudget { get; set; }
    public DateTime DateDebutProjet { get; set; }
    public DateTime DateFinProjet { get; set; }
    public int ChargerDeProjetId { get; set; }
    public bool IsActive { get; set; }
}
public class ProjectCreateDTO
{
    public string Name { get; set; }
    public int OrganismeId { get; set; }
    public string Color { get; set; }
    public decimal MontantBudget { get; set; }
    public DateTime DateDebutProjet { get; set; }
    public DateTime DateFinProjet { get; set; }
    public int ChargerDeProjetId { get; set; }
    public bool IsActive { get; set; }
}

public class ProjectUpdateDTO
{
    public string Name { get; set; }
    public int OrganismeId { get; set; }
    public string Color { get; set; }
    public decimal MontantBudget { get; set; }
    public DateTime DateDebutProjet { get; set; }
    public DateTime DateFinProjet { get; set; }
    public int ChargerDeProjetId { get; set; }
    public bool IsActive { get; set; }
}

public class ProjectDeleteDTO
{
    public bool IsActive { get; set; }
}

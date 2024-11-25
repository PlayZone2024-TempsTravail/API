namespace PlayZone.API.DTOs.Budget_Related;

public class OrganismeDTO
{
    public int IdOrganisme { get; set; }
    public string Name { get; set; }
}

public class OrganismeCreateFormDTO
{
    public string Name { get; set; }
}


public class OrganismeUpdateFormDTO
{
    public string Name { get; set; }
}

namespace PlayZone.API.DTOs.Budget_Related;

public class LibeleDTO
{
    public int IdLibele { get; set; }
    public int IdCategory { get; set; }
    public string Name { get; set; }
}

public class LibeleCreateFormDTO
{
    public int IdCategory { get; set; }
    public string Name { get; set; }
}


public class LibeleUpdateFormDTO
{
    public int IdCategory { get; set; }
    public string Name { get; set; }
}

namespace PlayZone.API.DTOs.Budget_Related;

public class LibeleDTO
{
    public bool IsIncome { get; set; }
    public int IdCategory  { get; set; }
    public string CategoryName  { get; set; }
    public int IdLibele  { get; set; }
    public string LibeleName  { get; set; }
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

public class TreeLibeleDTO
{
    public required string key  { get; set; }
    public required string label  { get; set; }
}

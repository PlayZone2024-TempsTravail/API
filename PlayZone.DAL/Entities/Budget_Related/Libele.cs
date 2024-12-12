namespace PlayZone.DAL.Entities.Budget_Related;

public class Libele
{
    public bool IsIncome { get; set; }
    public int IdCategory  { get; set; }
    public string CategoryName  { get; set; }
    public int IdLibele  { get; set; }
    public string LibeleName  { get; set; }
}

public class TreeLibele
{
    public required string CategoryId  { get; set; }
    public required string CategoryName  { get; set; }
    public required string LibeleId  { get; set; }
    public required string LibeleName  { get; set; }
}

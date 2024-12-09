namespace PlayZone.BLL.Models.Budget_Related;

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
    public required string LibeleId  { get; set; }
    public required string LibeleName  { get; set; }
}

public class PreparedLibele
{
    public required string Name { get; set; }
    public List<PreparedInOut> InOuts { get; set; } = new List<PreparedInOut>();
}

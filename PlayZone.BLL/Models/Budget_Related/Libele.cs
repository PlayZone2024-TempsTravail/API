namespace PlayZone.BLL.Models.Budget_Related;

public class Libele
{
    public int IdLibele  { get; set; }
    public int IdCategory  { get; set; }
    public string Name  { get; set; }
}

public class PreparedLibele
{
    public required string Name { get; set; }
    public List<PreparedInOut> InOuts { get; set; } = new List<PreparedInOut>();
}

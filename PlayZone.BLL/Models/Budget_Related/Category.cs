namespace PlayZone.BLL.Models.Budget_Related;

public class Category
{
    public int IdCategory { get; set; }
    public string Name { get; set; }
    public bool IsIncome { get; set; }
    public bool EstimationParCategorie { get; set; }
}

public class TreeCategory
{
    public required string CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public List<TreeLibele> Libeles { get; set; }
}

public class PreparedCategory
{
    public required string Name { get; init; }
    public List<PreparedLibele> Libelles { get; set; } = new List<PreparedLibele>();
}

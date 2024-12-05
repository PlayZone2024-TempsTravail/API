namespace PlayZone.API.DTOs.Budget_Related;

public class CategoryDTO
{
    public int IdCategory{ get; set; }
    public string Name { get; set; }
    public bool IsIncome { get; set; }
    public bool EstimationParCategorie { get; set; }
}

public class CategoryCreateFormDTO
{
    public string Name { get; set; }
    public bool IsIncome { get; set; }
    public bool EstimationParCategorie { get; set; }
}

public class CategoryUpdateFormDTO
{
    public string Name { get; set; }
    public bool IsIncome { get; set; }
    public bool EstimationParCategorie { get; set; }
}

public class TreeCategoryDTO
{
    public required string key { get; set; }
    public required string label { get; set; }
    public IEnumerable<TreeLibeleDTO> children { get; set; } = new List<TreeLibeleDTO>();
}

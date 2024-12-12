using PlayZone.BLL.Models.Budget_Related;
using Entities = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class CategoryMapper
{
    public static Entities.Category ToEntity(this Category category)
    {
        return new Entities.Category
        {
            IdCategory = category.IdCategory,
            Name = category.Name,
            IsIncome = category.IsIncome,
            EstimationParCategorie = category.EstimationParCategorie,
        };
    }

    public static Category ToModel(this Entities.Category category)
    {
        return new Category
        {
            IdCategory = category.IdCategory,
            Name = category.Name,
            IsIncome = category.IsIncome,
            EstimationParCategorie = category.EstimationParCategorie,
        };
    }
}

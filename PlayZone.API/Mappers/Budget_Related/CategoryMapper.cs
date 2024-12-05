using PlayZone.API.DTOs.Budget_Related;
using Models = PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Mappers.Budget_Related;

public static class CategoryMapper
{
    public static CategoryDTO ToDTO(this Models.Category category)
    {
        return new CategoryDTO()
        {
            IdCategory = category.IdCategory,
            Name = category.Name,
            IsIncome = category.IsIncome,
            EstimationParCategorie = category.EstimationParCategorie
        };
    }

    public static Models.Category ToModels(this CategoryDTO category)
    {
        return new Models.Category
        {
            IdCategory = category.IdCategory,
            Name = category.Name,
            IsIncome = category.IsIncome,
            EstimationParCategorie = category.EstimationParCategorie
        };
    }

    public static Models.Category ToModels(this CategoryCreateFormDTO category)
    {
        return new Models.Category
        {
            Name = category.Name,
            IsIncome = category.IsIncome,
            EstimationParCategorie = category.EstimationParCategorie
        };
    }

    public static Models.Category ToModels(this CategoryUpdateFormDTO category)
    {
        return new Models.Category
        {
            Name = category.Name,
            IsIncome = category.IsIncome,
            EstimationParCategorie = category.EstimationParCategorie
        };
    }

    public static TreeCategoryDTO ToDTO(this Models.TreeCategory category)
    {
        return new TreeCategoryDTO()
        {
            key = category.CategoryId,
            label = category.CategoryName,
            children = category.Libeles.Select(l => l.ToDTO())
        };
    }
}

using Models = PlayZone.BLL.Models.Budget_Related;
using PlayZone.API.DTOs.Budget_Related;

namespace PlayZone.API.Mappers.Budget_Related;

public static class PrevisionBudgetCategoryMapper
{
    public static Models.PrevisionBudgetCategory ToModel(this PrevisionBudgetCategoryDTO dto)
    {
        return new Models.PrevisionBudgetCategory
        {
            IdPrevisionBudgetCategory = dto.IdPrevisionBudgetCategory,
            ProjectId = dto.ProjectId,
            CategoryId = dto.CategoryId,
            CategoryName = dto.CategoryName,
            IsIncome = dto.IsIncome,
            Date = dto.Date,
            Montant = dto.Montant,
            Motif = dto.Motif
        };
    }

    public static Models.PrevisionBudgetCategory ToModel(this PrevisionBudgetCategoryCreateDTO dto)
    {
        return new Models.PrevisionBudgetCategory
        {
            ProjectId = dto.projectId,
            CategoryId = dto.categoryId,
            Date = dto.date,
            Montant = dto.montant,
            Motif = dto.motif
        };
    }

    public static Models.PrevisionBudgetCategory ToModel(this PrevisionBudgetCategoryUpdateDTO dto)
    {
        return new Models.PrevisionBudgetCategory
        {
            Date = dto.date,
            Montant = dto.montant,
            Motif = dto.motif
        };
    }

    public static PrevisionBudgetCategoryDTO ToDTO(this Models.PrevisionBudgetCategory model)
    {
        return new PrevisionBudgetCategoryDTO
        {
            IdPrevisionBudgetCategory = model.IdPrevisionBudgetCategory,
            ProjectId = model.ProjectId,
            CategoryId = model.CategoryId,
            CategoryName = model.CategoryName,
            IsIncome = model.IsIncome,
            Date = model.Date,
            Montant = model.Montant,
            Motif = model.Motif
        };
    }
}

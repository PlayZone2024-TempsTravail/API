using Models = PlayZone.BLL.Models.Budget_Related;
using PlayZone.API.DTOs.Budget_Related;

namespace PlayZone.API.Mappers.Budget_Related;

public static class PrevisionBudgetCategoryMapper
{
    public static Models.PrevisionBudgetCategory ToModel(this PrevisionBudgetCategoryDTO dto)
    {
        return new Models.PrevisionBudgetCategory
        {
            idPrevisionBudgetCategory = dto.idPrevisionBudgetCategory,
            projectId = dto.projectId,
            categoryId = dto.categoryId,
            date = dto.date,
            montant = dto.montant,
            motif = dto.motif
        };
    }

    public static Models.PrevisionBudgetCategory ToModel(this PrevisionBudgetCategoryCreateDTO dto)
    {
        return new Models.PrevisionBudgetCategory
        {

            projectId = dto.projectId,
            categoryId = dto.categoryId,
            date = dto.date,
            montant = dto.montant,
            motif = dto.motif
        };
    }

    public static Models.PrevisionBudgetCategory ToModel(this PrevisionBudgetCategoryUpdateDTO dto)
    {
        return new Models.PrevisionBudgetCategory
        {
            date = dto.date,
            montant = dto.montant,
            motif = dto.motif
        };
    }

    public static PrevisionBudgetCategoryDTO ToDTO(this Models.PrevisionBudgetCategory model)
    {
        return new PrevisionBudgetCategoryDTO
        {
            idPrevisionBudgetCategory = model.idPrevisionBudgetCategory,
            projectId = model.projectId,
            categoryId = model.categoryId,
            date = model.date,
            montant = model.montant,
            motif = model.motif
        };
    }
}

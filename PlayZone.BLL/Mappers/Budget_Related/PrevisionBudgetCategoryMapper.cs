using Entities = PlayZone.DAL.Entities.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class PrevisionBudgetCategoryMapper
{
    public static PrevisionBudgetCategory ToModel(this Entities.PrevisionBudgetCategory entity)
    {
        return new PrevisionBudgetCategory
        {
            idPrevisionBudgetCategory = entity.idPrevisionBudgetCategory,
            projectId = entity.projectId,
            categoryId = entity.categoryId,
            date = entity.date,
            montant = entity.montant,
            motif = entity.motif
        };
    }

    public static Entities.PrevisionBudgetCategory ToEntity(this PrevisionBudgetCategory model)
    {
        return new Entities.PrevisionBudgetCategory
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

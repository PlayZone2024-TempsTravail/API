using Entities = PlayZone.DAL.Entities.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class PrevisionBudgetCategoryMapper
{
    public static PrevisionBudgetCategory ToModel(this Entities.PrevisionBudgetCategory entity)
    {
        return new PrevisionBudgetCategory
        {
            IdPrevisionBudgetCategory = entity.IdPrevisionBudgetCategory,
            ProjectId = entity.ProjectId,
            CategoryId = entity.CategoryId,
            CategoryName = entity.CategoryName,
            IsIncome = entity.IsIncome,
            Date = entity.Date,
            Montant = entity.Montant,
            Motif = entity.Motif
        };
    }

    public static Entities.PrevisionBudgetCategory ToEntity(this PrevisionBudgetCategory model)
    {
        return new Entities.PrevisionBudgetCategory
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

using PlayZone.BLL.Models.Budget_Related;
using Entities = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class PrevisionBudgetLibeleMapper
{
    public static Entities.PrevisionBudgetLibele ToEntity(this PrevisionBudgetLibele model)
    {
        return new Entities.PrevisionBudgetLibele
        {
            IdPrevisionBudgetLibele = model.IdPrevisionBudgetLibele,
            IdProject = model.IdProject,
            IdLibele = model.IdLibele,
            Date = model.Date,
            Motif = model.Motif,
            Montant = model.Montant
        };
    }
    public static PrevisionBudgetLibele ToModel(this Entities.PrevisionBudgetLibele entity)
    {
        return new PrevisionBudgetLibele
        {
            IdPrevisionBudgetLibele = entity.IdPrevisionBudgetLibele,
            IdProject = entity.IdProject,
            IdLibele = entity.IdLibele,
            Date = entity.Date,
            Motif = entity.Motif,
            Montant = entity.Montant
        };
    }
}

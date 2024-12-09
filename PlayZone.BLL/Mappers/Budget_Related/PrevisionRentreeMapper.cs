using PlayZone.BLL.Models.Budget_Related;
using Entities = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class PrevisionRentreeMapper
{
    public static Entities.PrevisionRentree ToEntity(this PrevisionRentree previsionRentree)
    {
        return new Entities.PrevisionRentree
        {
            IdPrevisionRentree = previsionRentree.IdPrevisionRentree,
            CategoryId = previsionRentree.CategoryId,
            CategoryName = previsionRentree.CategoryName,
            LibeleId = previsionRentree.LibeleId,
            ProjectId = previsionRentree.ProjectId,
            OrganismeId = previsionRentree.OrganismeId,
            Date = previsionRentree.Date,
            Motif = previsionRentree.Motif,
            Montant = previsionRentree.Montant,
        };
    }

    public static PrevisionRentree ToModel(this Entities.PrevisionRentree previsionRentree)
    {
        return new PrevisionRentree
        {
            IdPrevisionRentree = previsionRentree.IdPrevisionRentree,
            CategoryId = previsionRentree.CategoryId,
            CategoryName = previsionRentree.CategoryName,
            LibeleId = previsionRentree.LibeleId,
            LibeleName = previsionRentree.LibeleName,
            ProjectId = previsionRentree.ProjectId,
            OrganismeId = previsionRentree.OrganismeId,
            Date = previsionRentree.Date,
            Motif = previsionRentree.Motif,
            Montant = previsionRentree.Montant,
        };
    }
}

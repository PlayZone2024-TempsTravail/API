using PlayZone.API.DTOs.Budget_Related;
using Models = PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Mappers.Budget_Related;

public static class PrevisionRentreeMapper
{
    public static PrevisionRentreeDTO ToDTO(this Models.PrevisionRentree previsionRentree)
    {
        return new PrevisionRentreeDTO
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

    public static Models.PrevisionRentree ToModel(this PrevisionRentreeDTO previsionRentree)
    {
        return new Models.PrevisionRentree
        {
            IdPrevisionRentree = previsionRentree.IdPrevisionRentree,
            LibeleId = previsionRentree.LibeleId,
            ProjectId = previsionRentree.ProjectId,
            OrganismeId = previsionRentree.OrganismeId,
            Date = previsionRentree.Date,
            Motif = previsionRentree.Motif,
            Montant = previsionRentree.Montant,
        };
    }

    public static Models.PrevisionRentree ToModel(this PrevisionRentreeCreateDTO previsionRentree)
    {
        return new Models.PrevisionRentree
        {
            LibeleId = previsionRentree.LibeleId,
            ProjectId = previsionRentree.ProjectId,
            OrganismeId = previsionRentree.OrganismeId,
            Date = previsionRentree.Date,
            Motif = previsionRentree.Motif,
            Montant = previsionRentree.Montant,
        };
    }

    public static Models.PrevisionRentree ToModel(this PrevisionRentreeUpdateDTO previsionRentree)
    {
        return new Models.PrevisionRentree
        {
            LibeleId = previsionRentree.LibeleId,
            ProjectId = previsionRentree.ProjectId,
            OrganismeId = previsionRentree.OrganismeId,
            Date = previsionRentree.Date,
            Motif = previsionRentree.Motif,
            Montant = previsionRentree.Montant,
        };
    }

    public static Models.PrevisionRentree ToModel(this PrevisionRentreeDeleteDTO previsionRentree)
    {
        return new Models.PrevisionRentree
        {
            IdPrevisionRentree = previsionRentree.IdPrevisionRentree,
        };
    }
}

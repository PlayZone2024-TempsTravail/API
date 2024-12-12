using PlayZone.BLL.Models.Budget_Related;
using Entities = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class LibeleMapper
{
    public static Entities.Libele ToEntity(this Libele libele)
    {
        return new Entities.Libele
        {
            IdLibele = libele.IdLibele,
            LibeleName = libele.LibeleName,
            IdCategory = libele.IdCategory,
            CategoryName = libele.CategoryName,
            IsIncome = libele.IsIncome
        };
    }

    public static Libele ToModel(this Entities.Libele libele)
    {
        return new Libele
        {
            IdLibele = libele.IdLibele,
            LibeleName = libele.LibeleName,
            IdCategory = libele.IdCategory,
            CategoryName = libele.CategoryName,
            IsIncome = libele.IsIncome
        };
    }
}

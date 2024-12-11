using PlayZone.API.DTOs.Budget_Related;
using Models = PlayZone.BLL.Models.Budget_Related;


namespace PlayZone.API.Mappers.Budget_Related;

public static class LibeleMapper
{
    public static LibeleDTO ToDTO(this Models.Libele libele)
    {
        return new LibeleDTO
        {
            IdLibele = libele.IdLibele,
            LibeleName = libele.LibeleName,
            IdCategory = libele.IdCategory,
            CategoryName = libele.CategoryName,
            IsIncome = libele.IsIncome
        };
    }

    public static Models.Libele ToModel(this LibeleDTO libele)
    {
        return new Models.Libele
        {
            IdLibele = libele.IdLibele,
            LibeleName = libele.LibeleName,
            IdCategory = libele.IdCategory,
            CategoryName = libele.CategoryName,
            IsIncome = libele.IsIncome
        };
    }

    public static Models.Libele ToModel(this LibeleCreateFormDTO libele)
    {
        return new Models.Libele
        {
            IdCategory = libele.IdCategory,
            LibeleName = libele.Name
        };
    }

    public static Models.Libele ToModel(this LibeleUpdateFormDTO libele)
    {
        return new Models.Libele
        {
            IdCategory = libele.IdCategory,
            LibeleName = libele.Name
        };
    }

    public static TreeLibeleDTO ToDTO(this Models.TreeLibele libele)
    {
        return new TreeLibeleDTO
        {
            key = libele.LibeleId,
            label = libele.LibeleName
        };
    }
}

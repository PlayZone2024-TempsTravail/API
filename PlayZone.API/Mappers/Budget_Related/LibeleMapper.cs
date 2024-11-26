using PlayZone.API.DTOs.Budget_Related;
using Libele = PlayZone.BLL.Models.Budget_Related.Libele;


namespace PlayZone.API.Mappers.Budget_Related;

public static class LibeleMapper
{
    public static LibeleDTO ToDTO(this Libele libele)
    {
        return new LibeleDTO
        {
            IdLibele = libele.IdLibele,
            IdCategory = libele.IdCategory,
            Name = libele.Name
        };
    }

    public static Libele ToModels(this LibeleDTO libele)
    {
        return new Libele
        {
            IdLibele = libele.IdLibele,
            IdCategory = libele.IdCategory,
            Name = libele.Name
        };
    }

    public static Libele ToModels(this LibeleCreateFormDTO libele)
    {
        return new Libele
        {
            IdCategory = libele.IdCategory,
            Name = libele.Name
        };
    }

    public static Libele ToModels(this LibeleUpdateFormDTO libele)
    {
        return new Libele
        {
            IdCategory = libele.IdCategory,
            Name = libele.Name
        };
    }
}

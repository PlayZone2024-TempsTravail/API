using PlayZone.API.DTOs.Libele_Related;
using Models = PlayZone.BLL.Models.Libele_Related;


namespace PlayZone.API.Mappers.Libele_Related;

public static class LibeleMapper
{
    public static LibeleDTO ToDTO(this Models.Libele libele)
    {
        return new LibeleDTO
        {
            IdLibele = libele.IdLibele,
            IdCategory = libele.IdCategory,
            Name = libele.Name
        };
    }

    public static Models.Libele ToModels(this LibeleDTO libele)
    {
        return new Models.Libele
        {
            IdLibele = libele.IdLibele,
            IdCategory = libele.IdCategory,
            Name = libele.Name
        };
    }

    public static Models.Libele ToModels(this LibeleCreateFormDTO libele)
    {
        return new Models.Libele
        {
            IdCategory = libele.IdCategory,
            Name = libele.Name
        };
    }

    public static Models.Libele ToModels(this LibeleUpdateFormDTO libele)
    {
        return new Models.Libele
        {
            IdCategory = libele.IdCategory,
            Name = libele.Name
        };
    }
}

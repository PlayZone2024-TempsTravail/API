using PlayZone.BLL.Models.Libele_Related;
using Entities = PlayZone.DAL.Entities.Libele_Related;

namespace PlayZone.BLL.Mappers.Libele_Related;

public static class LibeleMapper
{
    public static Entities.Libele ToEntities(this Libele libele)
    {
        return new Entities.Libele
        {
            IdLibele = libele.IdLibele,
            IdCategory = libele.IdCategory,
            Name = libele.Name
        };
    }

    public static Libele ToModels(this Entities.Libele libele)
    {
        return new Libele
        {
            IdLibele = libele.IdLibele,
            IdCategory = libele.IdCategory,
            Name = libele.Name
        };
    }
}

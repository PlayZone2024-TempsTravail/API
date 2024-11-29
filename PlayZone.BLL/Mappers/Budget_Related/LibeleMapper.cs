using PlayZone.BLL.Models.Budget_Related;
using Entities = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

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

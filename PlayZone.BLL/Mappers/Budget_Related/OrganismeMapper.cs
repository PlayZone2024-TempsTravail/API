using PlayZone.BLL.Models.Budget_Related;
using Entities = PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Mappers.Budget_Related;

public static class OrganismeMapper
{
    public static Entities.Organisme ToEntities(this Organisme organisme)
    {
        return new Entities.Organisme
        {
            IdOrganisme = organisme.IdOrganisme,
            Name = organisme.Name
        };
    }

    public static Organisme ToModels(this Entities.Organisme organisme)
    {
        return new Organisme
        {
            IdOrganisme = organisme.IdOrganisme,
            Name = organisme.Name
        };
    }
}

using PlayZone.API.DTOs.Budget_Related;
using Models = PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Mappers.Budget_Related;

public static class OrganismeMapper
{
    public static OrganismeDTO ToDTO(this Models.Organisme organisme)
    {
        return new OrganismeDTO
        {
            IdOrganisme = organisme.IdOrganisme,
            Name = organisme.Name
        };
    }

    public static Models.Organisme ToModels(this OrganismeDTO organisme)
    {
        return new Models.Organisme
        {
            IdOrganisme = organisme.IdOrganisme,
            Name = organisme.Name
        };
    }

    public static Models.Organisme ToModels(this OrganismeCreateFormDTO organisme)
    {
        return new Models.Organisme
        {
            Name = organisme.Name
        };
    }

    public static Models.Organisme ToModels(this OrganismeUpdateFormDTO organisme)
    {
        return new Models.Organisme
        {
            Name = organisme.Name
        };
    }
}

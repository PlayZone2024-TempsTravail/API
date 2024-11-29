using Entities = PlayZone.DAL.Entities.User_Related;
using PlayZone.BLL.Models.User_Related;

namespace PlayZone.BLL.Mappers.User_Related;

public static class CompteurWorktimeCategoryMapper
{
    public static CompteurWorktimeCategory ToModel(this Entities.CompteurWorktimeCategory compteurWorktimeCategory)
    {
        return new CompteurWorktimeCategory
        {
            UserId = compteurWorktimeCategory.UserId,
            WorktimeCategoryId = compteurWorktimeCategory.WorktimeCategoryId,
            Quantity = compteurWorktimeCategory.Quantity
        };
    }

    public static Entities.CompteurWorktimeCategory ToEntity(this CompteurWorktimeCategory compteurWorktimeCategory)
    {
        return new Entities.CompteurWorktimeCategory
        {
            UserId = compteurWorktimeCategory.UserId,
            WorktimeCategoryId = compteurWorktimeCategory.WorktimeCategoryId,
            Quantity = compteurWorktimeCategory.Quantity
        };
    }
}

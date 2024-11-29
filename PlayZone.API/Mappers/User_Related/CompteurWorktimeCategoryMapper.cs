using PlayZone.API.DTOs.User_Related;
using Models = PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Mappers.User_Related;

public static class CompteurWorktimeCategoryMapper
{
    public static CompteurWorktimeCategoryDTO ToDTO(this Models.CompteurWorktimeCategory compteurWorktimeCategory)
    {
        return new CompteurWorktimeCategoryDTO
        {
            UserId = compteurWorktimeCategory.UserId,
            WorktimeCategoryId = compteurWorktimeCategory.WorktimeCategoryId,
            Quantity = compteurWorktimeCategory.Quantity
        };
    }

    public static CompteurWorktimeCategoryUpdateDTO ToUpdateDTO(this Models.CompteurWorktimeCategory compteurWorktimeCategory)
    {
        return new CompteurWorktimeCategoryUpdateDTO
        {
            WorktimeCategoryId = compteurWorktimeCategory.WorktimeCategoryId,
            Quantity = compteurWorktimeCategory.Quantity
        };
    }

    public static Models.CompteurWorktimeCategory ToModel(this CompteurWorktimeCategoryDTO compteurWorktimeCategory)
    {
        return new Models.CompteurWorktimeCategory
        {
            UserId = compteurWorktimeCategory.UserId,
            WorktimeCategoryId = compteurWorktimeCategory.WorktimeCategoryId,
            Quantity = compteurWorktimeCategory.Quantity
        };
    }

    public static Models.CompteurWorktimeCategory ToModel(
        this CompteurWorktimeCategoryUpdateDTO compteurWorktimeCategory)
    {
        return new Models.CompteurWorktimeCategory
        {
            WorktimeCategoryId = compteurWorktimeCategory.WorktimeCategoryId,
            Quantity = compteurWorktimeCategory.Quantity
        };
    }
}

using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
using CompteurWorktimeCategory = PlayZone.BLL.Models.User_Related.CompteurWorktimeCategory;

namespace PlayZone.BLL.Services.User_Related;

public class CompteurWorktimeCategoryService : ICompteurWorktimeCategoryService
{
    private ICompteurWorktimeCategoryRepository _compteurWorktimeCategoryRepository;

    public CompteurWorktimeCategoryService(ICompteurWorktimeCategoryRepository compteurWorktimeCategoryRepository)
    {
        this._compteurWorktimeCategoryRepository = compteurWorktimeCategoryRepository;
    }

    public IEnumerable<CompteurWorktimeCategory> GetAll()
    {
        return this._compteurWorktimeCategoryRepository.GetAll().Select(cw => cw.ToModel());
    }

    public IEnumerable<CompteurWorktimeCategory> GetByUser(int userId)
    {
        return this._compteurWorktimeCategoryRepository.GetByUser(userId).Select(cw => cw.ToModel());
    }

    public CompteurWorktimeCategory Create(CompteurWorktimeCategory compteurWorktimeCategory)
    {
        return this._compteurWorktimeCategoryRepository.Create(compteurWorktimeCategory.ToEntity()).ToModel();
    }

    public bool Update(CompteurWorktimeCategory compteurWorktimeCategory)
    {
        return this._compteurWorktimeCategoryRepository.Update(compteurWorktimeCategory.ToEntity());
    }

    public bool Delete(int userId, int worktimeCategoryId)
    {
        return this._compteurWorktimeCategoryRepository.Delete(userId, worktimeCategoryId);
    }
}

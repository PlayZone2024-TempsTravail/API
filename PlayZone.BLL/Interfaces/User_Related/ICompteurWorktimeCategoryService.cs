using CompteurWorktimeCategory = PlayZone.BLL.Models.User_Related.CompteurWorktimeCategory;

namespace PlayZone.BLL.Interfaces.User_Related;

public interface ICompteurWorktimeCategoryService
{
    public IEnumerable<CompteurWorktimeCategory> GetAll();
    public IEnumerable<CompteurWorktimeCategory> GetByUser(int userId);
    public CompteurWorktimeCategory Create(CompteurWorktimeCategory compteurWorktimeCategory);
    public bool Update(CompteurWorktimeCategory compteurWorktimeCategory);
    public bool Delete(int userId, int worktimeCategoryId);
}

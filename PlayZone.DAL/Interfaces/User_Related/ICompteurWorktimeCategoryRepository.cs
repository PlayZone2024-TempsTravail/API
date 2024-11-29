using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Entities.Worktime_Related;

namespace PlayZone.DAL.Interfaces.User_Related;

public interface ICompteurWorktimeCategoryRepository
{
    public IEnumerable<CompteurWorktimeCategory> GetAll();
    public IEnumerable<CompteurWorktimeCategory> GetByUser(int userId);
    public CompteurWorktimeCategory Create(CompteurWorktimeCategory compteurWorktimeCategory);
    public bool Update(CompteurWorktimeCategory compteurWorktimeCategory);
    public bool Delete(int userId, int worktimeCategoryId);
}

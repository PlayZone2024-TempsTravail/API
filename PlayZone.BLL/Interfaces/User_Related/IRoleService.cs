using PlayZone.BLL.Models.User_Related;

namespace PlayZone.BLL.Interfaces.User_Related;

public interface IRoleService
{
    public IEnumerable<Role> GetAll();
    public Role? GetById(int id);
    public int Create(Role role);
    public bool Update(Role role);
    public bool Delete(int id);
}

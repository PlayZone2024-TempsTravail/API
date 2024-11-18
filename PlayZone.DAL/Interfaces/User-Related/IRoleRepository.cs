using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.DAL.Interfaces.User_Related;

public interface IRoleRepository
{
    public IEnumerable<Role> GetAll();
    public Role? GetById(int id);
    public Role Create(Role role);
    public bool Update(Role role);
    public bool Delete(int id);
}

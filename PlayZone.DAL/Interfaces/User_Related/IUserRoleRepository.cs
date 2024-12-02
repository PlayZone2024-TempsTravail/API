using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.DAL.Interfaces.User_Related;

public interface IUserRoleRepository
{
    public IEnumerable<UserRole> GetAll();
    public IEnumerable<UserRole> GetByUser(int idRole);
    public UserRole Create(UserRole userRole);
    public bool Delete(int roleId, int userId);
}

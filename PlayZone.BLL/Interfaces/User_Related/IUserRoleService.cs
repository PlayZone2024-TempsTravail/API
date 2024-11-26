using PlayZone.BLL.Models.User_Related;

namespace PlayZone.BLL.Interfaces.User_Related;

public interface IUserRoleService
{
    public IEnumerable<UserRole> GetAll();
    public IEnumerable<int> GetByUser(int idRole);
    public UserRole Create(UserRole userRole);
    public bool Delete(int roleId, int userId);
}

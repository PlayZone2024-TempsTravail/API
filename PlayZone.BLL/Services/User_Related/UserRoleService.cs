using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using PlayZone.BLL.Models.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.BLL.Services.User_Related;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;
    public UserRoleService(IUserRoleRepository userRoleRepository)
    {
        this._userRoleRepository = userRoleRepository;
    }

    public IEnumerable<UserRole> GetAll()
    {
        return this._userRoleRepository.GetAll().Select(ur => ur.ToModel());
    }

    public IEnumerable<int> GetByUser(int idUser)
    {
        return this._userRoleRepository.GetByUser(idUser);
    }

    public UserRole Create(UserRole userRole)
    {
        return this._userRoleRepository.Create(userRole.ToEntity()).ToModel();
    }

    public bool Delete(int roleId, int userId)
    {
        return this._userRoleRepository.Delete(roleId, userId);
    }
}

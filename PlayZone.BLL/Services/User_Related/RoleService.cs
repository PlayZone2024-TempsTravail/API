using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using PlayZone.BLL.Models.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.BLL.Services.User_Related;

public class RoleService : IRoleService
{
    private IRoleRepository _roleRepository;
    public RoleService(IRoleRepository roleRepository)
    {
        this._roleRepository = roleRepository;
    }

    public IEnumerable<Role> GetAll()
    {
        return this._roleRepository.GetAll().Select(r => r.ToModel());
    }

    public Role? GetById(int id)
    {
        return this._roleRepository.GetById(id)?.ToModel();
    }

    public int Create(Role role)
    {
        return this._roleRepository.Create(role.ToEntities());
    }

    public bool Update(Role role)
    {
        return this._roleRepository.Update(role.ToEntities());
    }

    public bool Delete(int id)
    {
        return this._roleRepository.Delete(id);
    }
}

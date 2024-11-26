using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
using RolePermission = PlayZone.BLL.Models.User_Related.RolePermission;

namespace PlayZone.BLL.Services.User_Related;

public class RolePermissionService : IRolePermissionService
{
    private IRolePermissionRepository _rolePermissionRepository;
    public RolePermissionService(IRolePermissionRepository rolePermissionRepository)
    {
        this._rolePermissionRepository = rolePermissionRepository;
    }

    public IEnumerable<RolePermission> GetAll()
    {
        return this._rolePermissionRepository.GetAll().Select(rp => rp.ToModel());
    }

    public IEnumerable<RolePermission> GetByRole(int idRole)
    {
        return this._rolePermissionRepository.GetByRole(idRole).Select(rp => rp.ToModel());
    }

    public RolePermission Create(RolePermission rolePermission)
    {
        return this._rolePermissionRepository.Create(rolePermission.ToEntity()).ToModel();
    }

    public bool CheckPermission(int idUser, string permission)
    {
        return this._rolePermissionRepository.CheckPermission(idUser, permission);
    }

    public bool Delete(int idRole, string permissionId)
    {
        return this._rolePermissionRepository.Delete(idRole, permissionId);
    }
}

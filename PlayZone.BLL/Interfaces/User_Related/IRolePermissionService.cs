using RolePermission = PlayZone.BLL.Models.User_Related.RolePermission;

namespace PlayZone.BLL.Interfaces.User_Related;

public interface IRolePermissionService
{
    public IEnumerable<RolePermission> GetAll();
    public IEnumerable<RolePermission> GetByRole(int idRole);
    public RolePermission Create(RolePermission rolePermission);
    public bool CheckPermission(int idUser, string permission);
    public bool Delete(int id, int permissionId);
}

using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.DAL.Interfaces.User_Related;

public interface IRolePermissionRepository
{
    public IEnumerable<RolePermission> GetAll();
    public IEnumerable<RolePermission> GetByRole(int idRole);
    public RolePermission Create(RolePermission rolePermission);
    public bool CheckPermission(int idUser, Permission permission);
    public bool Delete(int id, int permissionId);
}

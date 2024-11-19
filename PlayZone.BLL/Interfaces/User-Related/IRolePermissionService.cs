using PlayZone.DAL.Entities.User_Related;
using RolePermission = PlayZone.BLL.Models.User_Related.RolePermission;

public interface IRolePermissionService
{
    public IEnumerable<RolePermission> GetAll();
    public IEnumerable<RolePermission> GetByRole(int idRole);
    public RolePermission Create(RolePermission rolePermission);
    public bool CheckPermission(int idUser, Permission permission);
    public bool Delete(int id, int permissionId);
}

using PlayZone.BLL.Models.User_Related;

namespace PlayZone.BLL.Interfaces.User_Related;

public interface IUserSalaireService
{
    public IEnumerable<UserSalaire> GetByUser(int idUser);
    public int Create(UserSalaire userSalaire);
}

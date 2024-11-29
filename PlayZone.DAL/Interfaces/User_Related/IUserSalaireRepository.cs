using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.DAL.Interfaces.User_Related;

public interface IUserSalaireRepository
{
    public IEnumerable<UserSalaire> GetByUser(int idUser);
    public int Create(UserSalaire userSalaire);
}

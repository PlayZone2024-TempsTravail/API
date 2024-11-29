using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using PlayZone.BLL.Models.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.BLL.Services.User_Related;

public class UserSalaireService : IUserSalaireService
{
    private readonly IUserSalaireRepository _userSalaireRepository;

    public UserSalaireService(IUserSalaireRepository userSalaireRepository)
    {
        this._userSalaireRepository = userSalaireRepository;
    }

    public IEnumerable<UserSalaire> GetByUser(int idUser)
    {
        return this._userSalaireRepository.GetByUser(idUser).Select(us => us.ToModel());
    }

    public int Create(UserSalaire userSalaire)
    {
        return this._userSalaireRepository.Create(userSalaire.ToEntity());
    }
}

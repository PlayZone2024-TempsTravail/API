using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using PlayZone.BLL.Models.User_Related;


namespace PlayZone.BLL.Services.User_Related;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserSalaireRepository _userSalaireRepository;

    public UserService(
        IUserRepository userRepository,
        IUserRoleRepository userRoleRepository,
        IUserSalaireRepository userSalaireRepository
    )
    {
        this._userRepository = userRepository;
        this._userRoleRepository = userRoleRepository;
        this._userSalaireRepository = userSalaireRepository;
    }

    public IEnumerable<User> GetAll()
    {
        IEnumerable<User> users = this._userRepository.GetAll().Select(u =>
        {
            User user = u.ToModel();
            user.UserRoles = this._userRoleRepository.GetByUser(user.IdUser).Select(us => us.ToModel());
            user.UserSalaires = this._userSalaireRepository.GetByUser(user.IdUser).Select(us => us.ToModel());
            return user;
        });
        return users;
    }

    public User? GetById(int id)
    {
        User? user = this._userRepository.GetById(id)?.ToModel();

        if (user == null) return null;

        user.UserSalaires = this._userSalaireRepository.GetByUser(id).Select(us => us.ToModel());
        user.UserRoles = this._userRoleRepository.GetByUser(id).Select(ur => ur.ToModel());
        return user;
    }

    public User? GetByEmail(string email)
    {
        return this._userRepository.GetByEmail(email)?.ToModel();
    }

    public int Create(User user)
    {
        // TODO
        string passwordAuto = "Test1234=";
        user.Password = passwordAuto;

        return this._userRepository.Create(user.ToEntity());
    }

    public bool Update(User user)
    {
        return this._userRepository.Update(user.ToEntity());
    }

    public bool Delete(int idUser)
    {
        this._userRepository.Delete(idUser);
        return this._userRepository.GetById(idUser)?.IsActive == false;
    }
}

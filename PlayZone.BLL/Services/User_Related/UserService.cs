using PlayZone.BLL.Helpers;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using User = PlayZone.BLL.Models.User_Related.User;

namespace PlayZone.BLL.Services.User_Related;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserSalaireRepository _userSalaireRepository;
    private readonly PasswordHelper _passwordHelper;

    public UserService(
        IUserRepository userRepository,
        IUserRoleRepository userRoleRepository,
        IUserSalaireRepository userSalaireRepository,
        PasswordHelper passwordHelper
    )
    {
        this._userRepository = userRepository;
        this._userRoleRepository = userRoleRepository;
        this._userSalaireRepository = userSalaireRepository;
        this._passwordHelper = passwordHelper;
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

    public async Task<int> Create(User user)
    {
        string password = this._passwordHelper.GeneratePassword();
        user.Password = this._passwordHelper.GenerateHash(user.Email, password);
        int idUser = this._userRepository.Create(user.ToEntity());
        await this._passwordHelper.New(user.Email, user.Nom, user.Prenom, password);
        return idUser;
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

    public async Task<bool> ResetPassword(int idUser)
    {
        User? user = this._userRepository.GetById(idUser)?.ToModel();
        if (user == null)
            return false;

        string password = this._passwordHelper.GeneratePassword();
        user.Password = this._passwordHelper.GenerateHash(user.Email, password);
        if (this._userRepository.ResetPassword(user.ToEntity()))
        {
            await this._passwordHelper.New(user.Email, user.Nom, user.Prenom, password);
            return true;
        }
        return false;
    }
}

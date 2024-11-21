using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using PlayZone.BLL.Models.User_Related;


namespace PlayZone.BLL.Services.User_Related;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public IEnumerable<User> GetAll()
    {
        return this._userRepository.GetAll().Select(u => u.ToModels());
    }

    public User? GetById(int id)
    {
        return this._userRepository.GetById(id)?.ToModels();
    }

    public User? GetByEmail(string email)
    {
        return this._userRepository.GetByEmail(email)?.ToModels();
    }

    public int Create(User user)
    {
        // TODO
        string passwordAuto = "Test1234=";
        user.Password = passwordAuto;

        return this._userRepository.Create(user.ToEntities());
    }

    public bool Update(User user)
    {
        return this._userRepository.Update(user.ToEntities());
    }

    public bool Delete(int idUser)
    {
        this._userRepository.Delete(idUser);
        return this._userRepository.GetById(idUser)?.IsActive == false;
    }
}

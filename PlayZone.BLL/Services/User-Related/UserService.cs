using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using PlayZone.BLL.Models.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.BLL.Services.User_Related;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public bool Update(User user)
    {
        return this._userRepository.Update(user.ToEntities());
    }

    public IEnumerable<User> GetAll()
    {
        return this._userRepository.GetAll().Select(u => u.ToModels());
    }

    public User GetById(int id)
    {
        return this._userRepository.GetById(id).ToModels();
    }

    public User GetByEmail(string email)
    {
        return this._userRepository.GetByEmail(email).ToModels();
    }
}

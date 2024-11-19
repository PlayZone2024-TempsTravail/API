using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
namespace PlayZone.BLL.Services.User_Related;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User Create(User user)
    {
        // TODO
        // toujours pas compris pour le mots de passe mais on ma dit après pour voir.
        string passwordAuto = "Test1234=";
        user.Password = passwordAuto;

        return _userRepository.Create(user.Entities()).ToModels();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public string Login(User user)
    {
        throw new NotImplementedException();
    }



    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}

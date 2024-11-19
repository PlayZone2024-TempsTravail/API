
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.BLL.Services.User_Related;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool Delete(int Id)
    {
        // TODO
        // voir pour que au retour il envoie bien le true ou false utiliser le getbyid pour return
        return _userRepository.Delete(Id);

    }

}

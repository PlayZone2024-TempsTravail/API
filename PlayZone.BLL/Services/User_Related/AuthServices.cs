using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
using User = PlayZone.BLL.Models.User_Related.User;

namespace PlayZone.BLL.Services.User_Related;

public class AuthServices : IAuthService
{

    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;
    public AuthServices(
        IConfiguration config,
        IUserRepository userRepository,
        IRolePermissionRepository rolePermissionRepository
    )
    {
        this._config = config;
        this._userRepository = userRepository;
    }

    public User? Login(User user)
    {
        User userDb = this._userRepository.Login(user.Email).ToModels();
        if (userDb.Email == user.Email  && userDb.Password == user.Password)
        {
            return userDb;
        }
        return null;
    }




}



using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using PlayZone.BLL.Mappers.User_Related;


namespace PlayZone.BLL.Services.User_Related;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    public UserService(IUserRepository userRepository, IAuthService authService)
    {
        this._userRepository = userRepository;
        this._authService = authService;
    }

    public User Create(User user)
    {
        // TODO
        // toujours pas compris pour le mots de passe mais on ma dit après pour voir.
        string passwordAuto = "Test1234=";
        user.Password = passwordAuto;

        return this._userRepository.Create(user.ToModel().ToEntities());
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public string Login(User user)
    {
        User userDb = this._userRepository.Login(user.Email);
        if (userDb.Email == user.Email  && userDb.Password == user.Password)
        {
            return this._authService.GenerateToken(user.ToModel());

        }
        throw new InvalidCastException();
    }



    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}

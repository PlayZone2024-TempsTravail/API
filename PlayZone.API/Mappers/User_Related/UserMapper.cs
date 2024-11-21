using PlayZone.API.DTOs.User_Related;
using PlayZone.BLL.Models.User_Related;


namespace PlayZone.API.Mappers.User_Related;

public static class UserMapper
{
    public static User ToModels(this UserLoginFormDTO user)
    {
        return new User
        {
            Email = user.Email,
            Password = user.Password,
        };
    }

    public static UserDTO ToDtO(this User user)
    {
        return new UserDTO
        {
            Email = user.Email,
            Password = user.Password,

        };
    }
}

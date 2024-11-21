using PlayZone.BLL.Models.User_Related;

namespace PlayZone.BLL.Interfaces.User_Related;

public interface IAuthService
{
    public string GenerateToken(User user);

}

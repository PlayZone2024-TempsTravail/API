using PlayZone.BLL.Models.User_Related;

namespace PlayZone.BLL.Interfaces.User_Related;

public interface IUserService
{
    public int Create(User user);
    public bool Delete(int Id);
}

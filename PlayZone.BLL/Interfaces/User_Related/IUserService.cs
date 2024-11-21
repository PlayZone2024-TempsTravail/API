using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.BLL.Interfaces.User_Related;

public interface IUserService
{
    public IEnumerable<User> GetAll();
    public string Login(User user);
    public User Create(User user);
    public bool Delete(int id);

}

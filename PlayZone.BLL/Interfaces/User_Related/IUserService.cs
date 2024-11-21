using PlayZone.BLL.Models.User_Related;

namespace PlayZone.BLL.Interfaces.User_Related;

public interface IUserService
{
    public IEnumerable<User> GetAll();
    public User? GetById(int id);
    public User? GetByEmail(string email);
    public int Create(User user);
    public bool Update(User user);
    public bool Delete(int id);
}

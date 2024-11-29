using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.DAL.Interfaces.User_Related;

public interface IUserRepository
{
    public IEnumerable<User> GetAll();
    public User? GetById(int id);
    public User? GetByEmail(string email);
    public int Create(User user);
    public bool Update(User user);
    public bool Delete(int id);
    public User? Login(string email);
}

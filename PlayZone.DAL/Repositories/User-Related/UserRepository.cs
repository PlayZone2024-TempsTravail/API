using System.Data.Common;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
using Dapper;
using Npgsql;

namespace PlayZone.DAL.Repositories.User_Related;

public class UserRepository : IUserRepository
{
    private readonly DbConnection _connection;

    public UserRepository(DbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<User> GetAll()
    {
        const string Query = @"SELECT isActive, nom, prenom, email, heures_annuelles_prestables, VA, VAEX,RC FROM ""USER""";
        return _connection.Query<User>(Query);
    }

    public User GetById(int id)
    {
        Const string Query = @"SELECT ID FROM ""USER""";
    }

    public User GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public User Create(User user)
    {
        throw new NotImplementedException();
    }

    public bool Update(User user)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}

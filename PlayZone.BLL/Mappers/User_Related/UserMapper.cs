using PlayZone.BLL.Models.User_Related;
using Entities = PlayZone.DAL.Entities.User_Related;

namespace PlayZone.BLL.Mappers.User_Related;

// TODO
// tout rouge je sais pas pourquoi :'(
public static class UserMapper
{
    public static Entities.User ToEntities(this User user)
    {
        return new Entities.User
        {
            IdUser = user.IdUser,
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            Password = user.Password,
            RoleId = user.RoleId,
        };
    }

    public static User ToModel(this Entities.User user)
    {
        return new User
        {
            IdUser = user.IdUser,
            Nom = user.Nom,
            Prenom = user.Prenom,
            Email = user.Email,
            Password = user.Password,
            RoleId = user.RoleId,
        };
    }
}

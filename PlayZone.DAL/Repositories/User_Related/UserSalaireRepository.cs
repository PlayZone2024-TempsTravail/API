using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.DAL.Repositories.User_Related;

public class UserSalaireRepository : IUserSalaireRepository
{
    private readonly NpgsqlConnection _connection;

    public UserSalaireRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<UserSalaire> GetByUser(int idUser)
    {
        const string query = @"
        SELECT
        ""id_userSalaire"" AS ""IdUserSalaire"",
        ""user_id"" AS ""UserId"",
        ""date"" AS ""Date"",
        ""regime"" AS ""Regime"",
        ""montant"" AS ""Montant""
        FROM ""UserSalaire""
        WHERE ""user_id"" = @idUser;
        ";
        return this._connection.Query<UserSalaire>(query, new { idUser = idUser });
    }

    public int Create(UserSalaire userSalaire)
    {
        const string @query = @"
                INSERT INTO ""UserSalaire"" (
                 ""user_id"",
                 ""date"",
                 ""regime"",
                 ""montant""
                 )
                VALUES (
                        @UserId,
                        @Date,
                        @Regime,
                        @Montant
                        )
                RETURNING ""id_userSalaire"" AS ""IdUserSalaire"";
                        ";
        int resultId = this._connection.QuerySingle<int>(query, new
        {
            UserId = userSalaire.UserId,
            Date = userSalaire.Date,
            Regime = userSalaire.Regime,
            Montant = userSalaire.Montant
        });
        return resultId;
    }
}

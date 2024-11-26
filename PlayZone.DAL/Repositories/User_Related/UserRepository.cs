using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.User_Related;
using PlayZone.DAL.Interfaces.User_Related;

namespace PlayZone.DAL.Repositories.User_Related
{
    public class UserRepository : IUserRepository
    {
        private readonly NpgsqlConnection _connection;

        public UserRepository(NpgsqlConnection connection)
        {
            this._connection = connection;
        }

        public IEnumerable<User> GetAll()
        {
            const string query = @"
                SELECT
                    ""id_user"" AS ""IdUser"",
                    ""isActive"",
                    ""nom"",
                    ""prenom"",
                    ""email""
                FROM ""User"";
            ";
            return this._connection.Query<User>(query);
        }

        public User? GetById(int id)
        {
            const string query = @"
                SELECT
                    ""id_user"" AS ""IdUser"",
                    ""isActive"",
                    ""nom"",
                    ""prenom"",
                    ""email""
                FROM ""User""
                WHERE ""id_user"" = @IdUser;
            ";
            return this._connection.QuerySingleOrDefault<User>(query, new { IdUser = id });
        }

        public User? GetByEmail(string email)
        {
            const string query = @"
                SELECT
                    ""id_user"" AS ""IdUser"",
                    ""isActive"",
                    ""nom"",
                    ""prenom"",
                    ""email""
                FROM ""User""
                WHERE ""email"" = @Email;
            ";
            return this._connection.QuerySingleOrDefault<User>(query, new { Email = email });
        }

        public User? Login(string email)
        {
            const string query = @"
                SELECT
                    ""id_user"" AS ""IdUser"",
                    ""email"",
                    ""password"",
                    ""nom"",
                    ""prenom""
                FROM ""User""
                WHERE ""email"" = @Email;
            ";
            return this._connection.QuerySingleOrDefault<User>(query, new { Email = email });
        }

        public int Create(User user)
        {
            const string query = @"
                INSERT INTO ""User"" (
                    ""id_user"",
                    ""nom"",
                    ""prenom"",
                    ""email"",
                    ""password""
                )
                VALUES (
                    DEFAULT,
                    @Nom,
                    @Prenom,
                    @Email,
                    @Password
                )
                RETURNING ""id_user"" AS ""IdUser"";
            ";
            int resultId = this._connection.QuerySingle<int>(query, new
            {
                user.Nom,
                user.Prenom,
                user.Email,
                user.Password,
            });

            return resultId;
        }

        public bool Update(User user)
        {
            const string query = @"
                UPDATE ""User"" SET
                    ""nom"" = @Nom,
                    ""prenom"" = @Prenom,
                    ""email"" = @Email
                WHERE ""id_user"" = @IdUser;
            ";
            int affectedRows = this._connection.Execute(query, new
            {
                user.IdUser,
                user.Nom,
                user.Prenom,
                user.Email
            });
            return affectedRows > 0;
        }

        public bool Delete(int id)
        {
            const string query = @"DELETE FROM ""User"" WHERE ""id_user"" = @IdUser;";
            int affectedRows = this._connection.Execute(query, new { IdUser = id });
            return affectedRows > 0;
        }
    }
}




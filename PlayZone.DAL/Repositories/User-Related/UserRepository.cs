using System.Data.Common;
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
                    ""id_user"",
                    ""role_id"",
                    ""isActive"",
                    ""nom"",
                    ""prenom"",
                    ""email"",
                    ""heures_annuelles_prestables"",
                    ""VA"",
                    ""VAEX"",
                    ""RC""
                FROM ""User"";
            ";
            return this._connection.Query<User>(query);
        }

        public User? GetById(int id)
        {
            const string query = @"
                SELECT
                    ""id_user"",
                    ""role_id"",
                    ""isActive"",
                    ""nom"",
                    ""prenom"",
                    ""email"",
                    ""heures_annuelles_prestables"",
                    ""VA"",
                    ""VAEX"",
                    ""RC""
                FROM ""User""
                WHERE ""id_user"" = @IdUser;
            ";
            return this._connection.QuerySingleOrDefault<User>(query, new { IdUser = id });
        }

        public User? GetByEmail(string email)
        {
            const string query = @"
                SELECT
                    ""id_user"",
                    ""role_id"",
                    ""isActive"",
                    ""nom"",
                    ""prenom"",
                    ""email"",
                    ""heures_annuelles_prestables"",
                    ""VA"",
                    ""VAEX"",
                    ""RC""
                FROM ""User""
                WHERE ""email"" = @Email;
            ";
            return this._connection.QuerySingleOrDefault<User>(query, new { Email = email });
        }

        public User Create(User user)
        {
            const string query = @"
                INSERT INTO ""User"" (
                    ""nom"",
                    ""prenom"",
                    ""email"",
                    ""role_id""
                    -- Include password if necessary
                )
                VALUES (
                    @Nom,
                    @Prenom,
                    @Email,
                    @RoleId
                    -- Include @Password if necessary
                )
                RETURNING *;
            ";
            return this._connection.QuerySingle<User>(query, new
            {
                Nom = user.Nom,
                Prenom = user.Prenom,
                Email = user.Email,
                RoleId = user.RoleId
                // Include Password = user.Password if necessary
            });
        }

        public bool Update(User user)
        {
            const string query = @"
                UPDATE ""User"" SET
                    ""nom"" = @Nom,
                    ""prenom"" = @Prenom,
                    ""email"" = @Email,
                    ""role_id"" = @RoleId,
                    ""heures_annuelles_prestables"" = @HeuresAnnuellesPrestables,
                    ""VA"" = @VA,
                    ""VAEX"" = @VAEX,
                    ""RC"" = @RC
                WHERE ""id_user"" = @IdUser;
            ";
            int affectedRows = this._connection.Execute(query, new
            {
                IdUser = user.IdUser,
                Nom = user.Nom,
                Prenom = user.Prenom,
                Email = user.Email,
                RoleId = user.RoleId,
                HeuresAnnuellesPrestables = user.HeuresAnnuellesPrestables,
                VA = user.VA,
                VAEX = user.VAEX,
                RC = user.RC
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

using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;
using System.Collections.Generic;

namespace PlayZone.DAL.Repositories.Budget_Related
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly NpgsqlConnection _connection;

        public TransactionRepository(NpgsqlConnection connection)
        {
            this._connection = connection;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            const string query = @"
                SELECT
                    'd' AS type,
                    d.id_depense AS id,
                    d.libele_id,
                    l.name AS libele_name,
                    d.project_id,
                    d.organisme_id,
                    d.montant,
                    d.date_facturation,
                    d.motif,
                    c.name AS category_name
                FROM ""Depense"" d
                INNER JOIN ""Libele"" l ON d.libele_id = l.id_libele
                INNER JOIN ""Category"" c ON l.category_id = c.id_category

                UNION

                SELECT
                    'r' AS type,
                    r.id_rentree AS id,
                    r.libele_id,
                    l.name AS libele_name,
                    r.project_id,
                    r.organisme_id,
                    r.montant,
                    r.date_facturation,
                    r.motif,
                    c.name AS category_name
                FROM ""Rentree"" r
                INNER JOIN ""Libele"" l ON r.libele_id = l.id_libele
                INNER JOIN ""Category"" c ON l.category_id = c.id_category

                ORDER BY type, id;
            ";

            return this._connection.Query<Transaction>(query);
        }
    }
}

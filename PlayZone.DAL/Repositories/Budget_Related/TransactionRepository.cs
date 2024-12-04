using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.DAL.Repositories.Budget_Related;
public class TransactionRepository : ITransactionRepository
{
    private readonly NpgsqlConnection _connection;

    public TransactionRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }

    public IEnumerable<Transaction> GetTransactionData(IEnumerable<int> libeles, IEnumerable<int> projectIds, DateTime startDate, DateTime endDate)
    {
        const string query = @"
            SELECT
                c.name AS Category,
                l.name AS Libele,
                o.name AS Organisme,
                d.motif AS Motif,
                d.date_facturation AS DateFacturation,
                d.montant AS Montant
            FROM ""Depense"" d
            LEFT JOIN ""Libele"" l ON d.libele_id = l.id_libele
            LEFT JOIN ""Category"" c ON l.category_id = c.id_category
            LEFT JOIN ""Organisme"" o ON o.id_organisme = d.organisme_id
            WHERE l.id_libele IN (@libeles)
            AND d.date_facturation BETWEEN @StartDate AND @EndDate
            AND d.project_id IN (@ProjectIds)

            UNION

            SELECT
                c.name AS Category,
                l.name AS Libele,
                o.name AS Organisme,
                r.motif AS Motif,
                r.date_facturation AS DateFacturation,
                r.montant AS Montant
            FROM ""Rentree"" r
            LEFT JOIN ""Libele"" l ON r.libele_id = l.id_libele
            LEFT JOIN ""Category"" c ON l.category_id = c.id_category
            LEFT JOIN ""Organisme"" o ON o.id_organisme = r.organisme_id
            WHERE l.id_libele IN (@libeles)
            AND r.date_facturation BETWEEN @StartDate AND @EndDate
            AND r.project_id IN (@ProjectIds)";

        var parameters = new
        {
            libeles = String.Join(',', libeles),
            ProjectIds = String.Join(',', projectIds),
            StartDate = startDate,
            EndDate = endDate
        };

        return this._connection.Query<Transaction>(query, parameters);
    }
}


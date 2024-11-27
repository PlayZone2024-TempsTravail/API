using Dapper;
using Npgsql;
using PlayZone.DAL.Entities.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.DAL.Repositories.Budget_Related;

public class PrevisionBudgetLibeleRepository : IPrevisionBudgetLibeleRepository
{
    private readonly NpgsqlConnection _connection;

    public PrevisionBudgetLibeleRepository(NpgsqlConnection connection)
    {
        this._connection = connection;
    }


    public PrevisionBudgetLibele GetById(int id)
    {
        throw new NotImplementedException();
    }

    public int Create(PrevisionBudgetLibele previsionBudgetLibele)
    {
        throw new NotImplementedException();
    }

    public bool Update(PrevisionBudgetLibele previsionBudgetLibele)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}

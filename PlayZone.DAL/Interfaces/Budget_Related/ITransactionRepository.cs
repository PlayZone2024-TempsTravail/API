using System.Collections.Generic;
using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.DAL.Interfaces.Budget_Related;

public interface ITransactionRepository
{
    IEnumerable<Transaction> GetAllTransactions();
}

using System.Collections.Generic;
using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.DAL.Interfaces.Budget_Related;

public interface ITransactionRepository
{
    public IEnumerable<Transaction> GetTransactionData(IEnumerable<int> libeles, IEnumerable<int> projectIds, DateTime startDate, DateTime endDate);
}

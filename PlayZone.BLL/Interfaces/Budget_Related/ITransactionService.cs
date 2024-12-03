using PlayZone.DAL.Entities.Budget_Related;

namespace PlayZone.BLL.Interfaces.Budget_Related
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAllTransactions();
    }
}

using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.BLL.Services.Budget_Related;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    public TransactionService(ITransactionRepository transactionRepository)
    {
        this._transactionRepository = transactionRepository;
    }

    public Object GenerateRapport(IEnumerable<int> libeles, IEnumerable<int> projectIds, DateTime startDate, DateTime endDate)
    {
        this._transactionRepository.GetTransactionData(libeles, projectIds, startDate, endDate);

        return new object();
    }
}

using PlayZone.BLL.Interfaces;
using PlayZone.DAL.Entities.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;
using System.Collections.Generic;
using PlayZone.BLL.Interfaces.Budget_Related;

namespace PlayZone.BLL.Services.Budget_Related
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return this._repository.GetAllTransactions();
        }
    }
}

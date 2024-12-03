using Microsoft.AspNetCore.Mvc;
using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.DAL.Entities.Budget_Related;
using System.Collections.Generic;

namespace PlayZone.API.Controllers.Budget_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this._transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            IEnumerable<Transaction> transactions = this._transactionService.GetAllTransactions();
            return this.Ok(transactions);
        }
    }
}

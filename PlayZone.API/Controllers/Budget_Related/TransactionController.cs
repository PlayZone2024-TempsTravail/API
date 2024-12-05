using Microsoft.AspNetCore.Mvc;
using PlayZone.BLL.Interfaces.Budget_Related;

namespace PlayZone.API.Controllers.Budget_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger)
        {
            this._transactionService = transactionService;
            this._logger = logger;
        }

        [HttpPost]
        public IActionResult GenerateRapport([FromQuery] IEnumerable<int> libele,[FromQuery] IEnumerable<int> projectIds, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var file = this._transactionService.GenerateRapport(libele, projectIds, startDate, endDate);
                return this.Ok(file);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

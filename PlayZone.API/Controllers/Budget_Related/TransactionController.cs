using Microsoft.AspNetCore.Mvc;
using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.DAL.Entities.Budget_Related;
using System.Collections.Generic;
using PlayZone.API.DTOs.Budget_Related;
using PlayZone.API.Mappers.Budget_Related;

namespace PlayZone.API.Controllers.Budget_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this._transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult GenerateRapport(IEnumerable<int> libele, IEnumerable<int> projectIds, DateTime startDate, DateTime endDate)
        {
            try
            {
                Object file = this._transactionService.GenerateRapport(libele, projectIds, startDate, endDate);
                return this.Ok(file);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayZone.BLL.Interfaces.Wortime_Related;

namespace PlayZone.API.Controllers.Worktime_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class WortimeController : ControllerBase
    {

        private readonly IWorktimeService _worktimeService;
        public WortimeController(IWorktimeService worktimeService)
        {
            this._worktimeService = worktimeService;
        }


        [HttpDelete("{idWorktime:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int idWorktime)
        {
            try
            {
                return this.Ok(this._worktimeService.DeleteWorktime(idWorktime));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.API.Controllers.User_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetPermissions()
        {
            try
            {
                return this.Ok(PermissionManager.PermissionsList);
            }
            catch (Exception e) { /* Ignored */ }
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}

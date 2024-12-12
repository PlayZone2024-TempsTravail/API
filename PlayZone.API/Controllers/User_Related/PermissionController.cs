using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.API.Controllers.User_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [PermissionAuthorize(Permission.MODIFIER_ROLE)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Permission[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPermissions()
        {
            try
            {
                return this.Ok(PermissionManager.PermissionsList);
            }
            catch (Exception)
            {
                /* Ignored */
            }

            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

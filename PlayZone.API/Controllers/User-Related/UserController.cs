using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.BLL.Interfaces.User_Related;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PlayZone.API.Controllers.User_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        //[Authorize]
        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update(int id, [FromBody] UserDTO.UserUpdateFormDTO user)
        {
            if (id <= 0)
            {
                return this.BadRequest("Invalid user data");
            }

            BLL.Models.User_Related.User updatedUser = user.ToModels();
            updatedUser.IdUser = id;
            if (this._userService.Update(updatedUser))
            {
                return this.Ok();
            }
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

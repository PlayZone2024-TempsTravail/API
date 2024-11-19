using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Mappers.User_Related;
using PlayZone.API.DTOs.User_Related;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
using UserMapper = PlayZone.API.Mappers.User_Related.UserMapper;

namespace PlayZone.API.Controllers.User_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserCreateFormDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult Create([FromBody] UserCreateFormDTO user)
        {
            int resultId = this._userService.Create(user.ToModel());
            if(resultId > 0)
            {
                return this.CreatedAtAction(nameof(this.GetUserById), new { id = resultId }, user);
            }
            return this.StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = this._userService.GetById(id);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }
    }
}

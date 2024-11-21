using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Mappers.User_Related;
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

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult Login([FromBody] UserLoginFormDTO user)
        {
            try
            {

                string token = this._userService.Login(user.ToModels().ToEntities());

                return this.Ok(new
                {
                    token,
                    email = user.Email,
                });
            }

            catch (ArgumentOutOfRangeException)
            {
                return this.NotFound("les crédentials de login sont incorrect");
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
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

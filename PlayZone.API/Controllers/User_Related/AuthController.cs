using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.BLL.Interfaces.User_Related;

namespace PlayZone.API.Controllers.User_Related;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        this._authService = authService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public IActionResult Login([FromBody] UserLoginFormDTO user)
    {
        try
        {
            string token = this._authService.Login(user.ToModels());

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
        catch (Exception)
        {
            return this.BadRequest();
        }
    }
}

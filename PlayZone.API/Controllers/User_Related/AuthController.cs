using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.API.Services;
using PlayZone.BLL.Exceptions;
using PlayZone.BLL.Interfaces.User_Related;

namespace PlayZone.API.Controllers.User_Related;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly JwtService _jwtService;

    public AuthController(IAuthService authService, JwtService jwtService)
    {
        this._authService = authService;
        this._jwtService = jwtService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public IActionResult Login([FromBody] UserLoginFormDTO userLoginFormDto)
    {
        try
        {
            UserLoginDTO? userLoginDto = this._authService.Login(userLoginFormDto.ToModel())?.ToLoginDTO();

            if (userLoginDto != null)
            {
                string token = this._jwtService.GenerateToken(userLoginDto);
                return this.Ok(new { token });
            }

            return this.NotFound("les crédentials de login sont incorrect");
        }
        catch (LoginException e)
        {
            return this.BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

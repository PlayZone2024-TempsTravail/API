using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.BLL.Interfaces.User_Related;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PlayZone.API.Controllers.User_Related;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        this._userService = userService;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        try
        {
            IEnumerable<UserDTO> users = this._userService.GetAll().Select(u => u.ToDTO());
            return this.Ok(users);
        }
        catch (Exception)
        {
            return this.NotFound("L'utilisateur est introuvable.");
        }
    }

    [HttpGet("GetById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetById(int id)
    {
        try
        {
            UserDTO user = this._userService.GetById(id).ToDTO();
            return this.Ok(user);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return this.NotFound("L'utilisateur est introuvable.");
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("GetByEmail/{email}")]
    public IActionResult GetByEmail(string email)
    {
        try
        {
            UserDTO user = this._userService.GetByEmail(email).ToDTO();
            return this.Ok(user);
        }
        catch (Exception)
        {
            return this.NotFound("L'utilisateur est introuvable.");
        }
    }

    //[Authorize]
    [HttpPut("Update/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Update(int id, [FromBody] UserDTO user)
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


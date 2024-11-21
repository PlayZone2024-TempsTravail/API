using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Controllers.User_Related;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userServices)
    {
        this._userService = userServices;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            IEnumerable<UserDTO> users = this._userService.GetAll().Select(u => u.ToDTO());
            return this.Ok(users);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("id/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetById(int id)
    {
        try
        {
            UserDTO user = this._userService.GetById(id).ToDTO();
            return this.Ok(user);
        }
        catch (Exception)
        {
            return this.NotFound("L'utilisateur est introuvable.");
        }
    }

    [HttpGet("email/{email}")]
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserCreateFormDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public IActionResult Create([FromBody] UserCreateFormDTO user)
    {
        int resultId = this._userService.Create(user.ToModels());
        if (resultId > 0)
        {
            return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, user);
        }
        return this.StatusCode(StatusCodes.Status500InternalServerError, resultId);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Update(int id, [FromBody] UserDTO user)
    {
        if (id <= 0)
        {
            return this.BadRequest("Invalid user data");
        }

        User updatedUser = user.ToModels();
        updatedUser.IdUser = id;
        if (this._userService.Update(updatedUser))
        {
            return this.Ok();
        }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete("{idUser:int}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Delete(int idUser)
    {
        try
        {
            return this.Ok(this._userService.Delete(idUser));
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

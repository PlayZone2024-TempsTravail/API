using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Entities.User_Related;
using User = PlayZone.BLL.Models.User_Related.User;

namespace PlayZone.API.Controllers.User_Related;

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
    [PermissionAuthorize(Permission.CONSULTER_UTILISATEUR)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    [PermissionAuthorize(Permission.CONSULTER_UTILISATEUR)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetById(int id)
    {
        try
        {
            UserDTO? user = this._userService.GetById(id)?.ToDTO();

            if (user != default)
            {
                return this.Ok(user);
            }

            return this.NotFound("L'utilisateur est introuvable.");
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("email/{email}")]
    [PermissionAuthorize(Permission.CONSULTER_UTILISATEUR)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetByEmail(string email)
    {
        try
        {
            UserDTO? user = this._userService.GetByEmail(email)?.ToDTO();

            if (user != default)
            {
                return this.Ok(user);
            }

            return this.NotFound("L'utilisateur est introuvable.");
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [PermissionAuthorize(Permission.AJOUTER_UTILISATEUR)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] UserCreateFormDTO user)
    {
        int resultId = this._userService.Create(user.ToModel());
        if (resultId > 0)
        {
            UserDTO u = this._userService.GetById(resultId)!.ToDTO();
            return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, u);
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError, resultId);
    }

    [HttpPut("{id}")]
    [PermissionAuthorize(Permission.MODIFIER_UTILISATEUR)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(int id, [FromBody] UserDTO user)
    {
        if (id <= 0)
        {
            return this.BadRequest("Invalid user data");
        }

        User updatedUser = user.ToModel();
        updatedUser.IdUser = id;
        if (this._userService.Update(updatedUser))
        {
            return this.Ok();
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete("{idUser:int}")]
    [PermissionAuthorize(Permission.SUPPRIMER_UTILISATEUR)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

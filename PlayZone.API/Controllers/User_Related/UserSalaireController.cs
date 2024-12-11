using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Entities.User_Related;
using Models = PlayZone.BLL.Models.User_Related;

namespace PlayZone.API.Controllers.User_Related;

[Route("api/[controller]")]
[ApiController]
public class UserSalaireController : ControllerBase
{
    private readonly IUserSalaireService _userSalaireService;

    public UserSalaireController(IUserSalaireService userSalaireService)
    {
        this._userSalaireService = userSalaireService;
    }

    [HttpGet("{userId:int}")]
    [Authorize]
    [PermissionAuthorize(Permission.EDIT_USER_SALAIRE)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserSalaireDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetByUser(int userId)
    {
        try
        {
            IEnumerable<UserSalaireDTO> userSalaires =
                this._userSalaireService.GetByUser(userId).Select(us => us.ToDTO());
            return this.Ok(userSalaires);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [Authorize]
    [PermissionAuthorize(Permission.EDIT_USER_SALAIRE)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] UserSalaireCreateDTO userSalaire)
    {
        try
        {
            int resultId = this._userSalaireService.Create(userSalaire.ToModel());
            if (resultId > 0)
            {
                return this.CreatedAtAction(nameof(this.GetByUser), new { userId = resultId }, userSalaire);
            }
        }
        catch (Exception)
        {
            /* ignored */
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }
}

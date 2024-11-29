using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.API.Controllers.User_Related;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        this._roleService = roleService;
    }

    [HttpGet]
    [PermissionAuthorize(Permission.CONSULTER_ROLES)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RoleDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        try
        {
            IEnumerable<RoleDTO> roles = this._roleService.GetAll().Select(r => r.ToDTO());
            return this.Ok(roles);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{idRole}")]
    [PermissionAuthorize(Permission.CONSULTER_ROLES)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetById(int idRole)
    {
        try
        {
            RoleDTO? role = this._roleService.GetById(idRole)?.ToDTO();
            if (role != null)
                return this.Ok(role);
            return this.NotFound();
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [PermissionAuthorize(Permission.CREER_ROLE)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RoleDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] RoleCreateDTO role)
    {
        try
        {
            int resultId = this._roleService.Create(role.ToModel());

            if (resultId > 0)
            {
                RoleDTO rl = this._roleService.GetById(resultId)!.ToDTO();
                return this.CreatedAtAction(nameof(this.GetById), new { idRole = resultId }, rl);
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }


    [HttpPut]
    [PermissionAuthorize(Permission.MODIFIER_ROLE)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update([FromBody] RoleDTO role)
    {
        try
        {
            if (this._roleService.Update(role.ToModel()))
            {
                return this.Ok();
            }

            return this.NotFound();
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("{idRole}")]
    [PermissionAuthorize(Permission.SUPPRIMER_ROLE)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(int idRole)
    {
        try
        {
            if (this._roleService.Delete(idRole))
            {
                return this.Ok();
            }

            return this.NotFound();
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

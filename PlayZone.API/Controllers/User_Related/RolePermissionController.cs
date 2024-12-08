using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Entities.User_Related;
using RolePermission = PlayZone.BLL.Models.User_Related.RolePermission;

namespace PlayZone.API.Controllers.User_Related;

[Route("api/[controller]")]
[ApiController]
public class RolePermissionController : ControllerBase
{
    private readonly IRolePermissionService _rolePermissionService;

    public RolePermissionController(IRolePermissionService rolePermissionService)
    {
        this._rolePermissionService = rolePermissionService;
    }

    [HttpGet]
    [PermissionAuthorize(Permission.CONSULTER_ROLES)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RolePermissionDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        try
        {
            IEnumerable<RolePermissionDTO> rolePermissions =
                this._rolePermissionService.GetAll().Select(rp => rp.ToDTO());
            return this.Ok(rolePermissions);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{idRole}")]
    [PermissionAuthorize(Permission.CONSULTER_ROLES)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<string>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetByRole(int idRole)
    {
        try
        {
            IEnumerable<string> rolePermissions = this._rolePermissionService.GetByRole(idRole).Select(rp => rp.PermissionId);
            return this.Ok(rolePermissions);
        }
        catch (Exception)
        {
            return this.NotFound("Le role est introuvable.");
        }
    }

    [HttpPost]
    [PermissionAuthorize(Permission.CREER_ROLE)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create(RolePermissionDTO rolePermissionFormDto)
    {
        try
        {
            RolePermission rp = this._rolePermissionService.Create(rolePermissionFormDto.ToModel());
            if (rp.RoleId == rolePermissionFormDto.RoleId && rp.PermissionId == rolePermissionFormDto.PermissionId)
            {
                return this.Ok();
            }
        }
        catch (Exception)
        {
            /* ignored */
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }


    [HttpPatch]
    [PermissionAuthorize(Permission.MODIFIER_UTILISATEUR)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(RolePermissionUpdateDTO userRoleUpdateDto)
    {
        try
        {
            foreach (RolePermissionDTO rolePermissionDto in userRoleUpdateDto.add)
            {
                this._rolePermissionService.Create(rolePermissionDto.ToModel());
            }

            foreach (RolePermissionDTO rolePermissionDto in userRoleUpdateDto.remove)
            {
                this._rolePermissionService.Delete(rolePermissionDto.RoleId, rolePermissionDto.PermissionId);
            }

            return this.Ok();
        }
        catch (Exception)
        {
            /* ignored */
        }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete]
    [PermissionAuthorize(Permission.SUPPRIMER_ROLE)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(RolePermissionDTO rolePermissionDto)
    {
        try
        {
            if (this._rolePermissionService.Delete(rolePermissionDto.RoleId, rolePermissionDto.PermissionId))
            {
                return this.Ok();
            }
        }
        catch (Exception)
        {
            /* ignored */
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }
}

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
    public IActionResult GetAll()
    {
        return this.Ok(this._roleService.GetAll());
    }

    [HttpGet("{idRole}")]
    [PermissionAuthorize(Permission.CONSULTER_ROLES)]
    public IActionResult GetById(int idRole)
    {
        return this.Ok(this._roleService.GetById(idRole));
    }

    [HttpPost]
    [PermissionAuthorize(Permission.CREER_ROLE)]
    public IActionResult Create([FromBody] RoleDTO role)
    {
        int resultId = this._roleService.Create(role.ToModel());

        if (resultId > 0)
        {
            return this.CreatedAtAction(nameof(this.GetById), new { idRole = resultId }, role);
        }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }


    [HttpPut("{idRole}")]
    [PermissionAuthorize(Permission.MODIFIER_ROLE)]
    public IActionResult Update([FromBody] RoleDTO role)
    {
        return this.Ok(this._roleService.Update(role.ToModel()));
    }

    [HttpDelete("{idRole}")]
    [PermissionAuthorize(Permission.SUPPRIMER_ROLE)]
    public IActionResult Delete(int idRole)
    {
        if (this._roleService.Delete(idRole))
        {
            return this.Ok();
        }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

}


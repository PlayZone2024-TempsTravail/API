using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTO;
using PlayZone.API.Mappers;
using PlayZone.DAL.Entities.User_Related;
using RolePermission = PlayZone.BLL.Models.User_Related.RolePermission;

namespace PlayZone.API.Controllers;

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
    public IActionResult GetAll()
    {
        return this.Ok(this._rolePermissionService.GetAll());
    }

    [HttpGet("{idRole}")]
    public IActionResult GetByRole(int idRole)
    {
        return this.Ok(this._rolePermissionService.GetByRole(idRole));
    }

    [HttpPost]
    public IActionResult Create(RolePermissionFormDTO rolePermissionFormDTO)
    {
        RolePermission rp = this._rolePermissionService.Create(rolePermissionFormDTO.ToModel());
        if (rp.RoleId == rolePermissionFormDTO.RoleId && rp.PermissionId == rolePermissionFormDTO.PermissionId)
        {
            return this.Ok();
        }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete("{idRole}/{permissionId}")]
    public IActionResult Delete(int idRole, int permissionId)
    {
        if (this._rolePermissionService.Delete(idRole, permissionId))
        {
            return this.Ok();
        }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }


}


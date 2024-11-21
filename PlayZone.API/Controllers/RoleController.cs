using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTO;
using PlayZone.API.Mappers;
using PlayZone.BLL.Interfaces.User_Related;

namespace PlayZone.API.Controllers;

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
    public IActionResult GetAll()
    {
        return this.Ok(this._roleService.GetAll());
    }

    [HttpGet("{idRole}")]
    public IActionResult GetById(int idRole)
    {
        return this.Ok(this._roleService.GetById(idRole));
    }

    [HttpPost]
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
    public IActionResult Update([FromBody] RoleDTO role)
    {
        return this.Ok(this._roleService.Update(role.ToModel()));
    }

    [HttpDelete("{idRole}")]
    public IActionResult Delete(int idRole)
    {
        if (this._roleService.Delete(idRole))
        {
            return this.Ok();
        }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

}


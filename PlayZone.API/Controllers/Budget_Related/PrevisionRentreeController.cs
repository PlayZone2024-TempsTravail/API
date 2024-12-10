using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.Budget_Related;
using PlayZone.API.Mappers.Budget_Related;
using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.DAL.Entities.User_Related;
using Models = PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Controllers.Budget_Related;

[Route("api/[controller]")]
[ApiController]
public class PrevisionRentreeController : ControllerBase
{
    private readonly IPrevisionRentreeService _previsionRentreeService;

    public PrevisionRentreeController(IPrevisionRentreeService previsionRentreeService)
    {
        this._previsionRentreeService = previsionRentreeService;
    }

    [HttpGet("{projectId:int}")]
    [Authorize]
    [PermissionAuthorize(Permission.SHOW_PROJECTS)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PrevisionRentreeDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetbyProject(int projectId)
    {
        try
        {
            IEnumerable<PrevisionRentreeDTO> previsionRentrees =
                this._previsionRentreeService.GetByProject(projectId).Select(pr => pr.ToDTO());
            return this.Ok(previsionRentrees);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("projets/{idPrevisionRentree:int}")]
    [Authorize]
    [PermissionAuthorize(Permission.SHOW_PROJECTS)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PrevisionRentreeDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetById(int idPrevisionRentree)
    {
        try
        {
            PrevisionRentreeDTO? previsionRentree = this._previsionRentreeService.GetById(idPrevisionRentree)?.ToDTO();
            if (previsionRentree != null)
                return this.Ok(previsionRentree);
            return this.NotFound("La prevision de rentree n'existe pas");
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }


    [HttpPost]
    [Authorize]
    [PermissionAuthorize(Permission.EDIT_PREVISION_RENTREE)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] PrevisionRentreeCreateDTO previsionRentree)
    {
        try
        {
            int resultId = this._previsionRentreeService.Create(previsionRentree.ToModel());
            if (resultId > 0)
            {
                return this.CreatedAtAction(nameof(this.GetById), new { idPrevisionRentree = resultId },
                    previsionRentree);
            }
        }
        catch (Exception)
        {
            /* ignored */
        }

        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }


    [HttpPut]
    [Authorize]
    [PermissionAuthorize(Permission.EDIT_PREVISION_RENTREE)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(int idPrevisionRentree, [FromBody] PrevisionRentreeUpdateDTO previsionRentree)
    {
        if (idPrevisionRentree <= 0)
        {
            return this.BadRequest("Invalid user data");
        }

        Models.PrevisionRentree updatedPrevisionRentree = previsionRentree.ToModel();
        updatedPrevisionRentree.IdPrevisionRentree = idPrevisionRentree;
        if (this._previsionRentreeService.Update(updatedPrevisionRentree))
        {
            return this.Ok();
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }


    [HttpDelete("{idPrevisionRentree:int}")]
    [Authorize]
    [PermissionAuthorize(Permission.DELETE_PREVISION_RENTREE)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(int idPrevisionRentree)
    {
        try
        {
            return this.Ok(this._previsionRentreeService.Delete(idPrevisionRentree));
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.Budget_Related;
using PlayZone.API.Mappers.Budget_Related;
using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.API.Controllers.Budget_Related;

[Route("api/[controller]")]
[ApiController]
public class OrganismeController : ControllerBase
{
    private readonly IOrganismeService _organismeService;

    public OrganismeController(IOrganismeService organismeService)
    {
        this._organismeService = organismeService;
    }

    [HttpGet]
    [Authorize]
    [PermissionAuthorize(Permission.SHOW_PROJECTS)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrganismeDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        try
        {
            IEnumerable<OrganismeDTO> organismes = this._organismeService.GetAll().Select(o => o.ToDTO());
            return this.Ok(organismes);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("fournisseursFirst")]
    [Authorize]
    [PermissionAuthorize(Permission.SHOW_PROJECTS)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrganismeDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAllFournisseursFirst()
    {
        try
        {
            IEnumerable<OrganismeDTO> organismes =
                this._organismeService.GetAllFournisseursFirst().Select(o => o.ToDTO());
            return this.Ok(organismes);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("clientsFirst")]
    [Authorize]
    [PermissionAuthorize(Permission.SHOW_PROJECTS)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrganismeDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAllClientsFirst()
    {
        try
        {
            IEnumerable<OrganismeDTO> organismes = this._organismeService.GetAllClientsFirst().Select(o => o.ToDTO());
            return this.Ok(organismes);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}")]
    [Authorize]
    [PermissionAuthorize(Permission.SHOW_PROJECTS)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrganismeDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetById(int id)
    {
        try
        {
            OrganismeDTO? organisme = this._organismeService.GetById(id)?.ToDTO();
            if (organisme == null)
            {
                return this.BadRequest("Organisme Not Found");
            }

            return this.Ok(organisme);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [Authorize]
    [PermissionAuthorize(Permission.EDIT_ORGANISME)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrganismeCreateFormDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] OrganismeCreateFormDTO organisme)
    {
        int resultId = this._organismeService.Create(organisme.ToModel());
        if (resultId > 0)
        {
            return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, organisme);
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError, resultId);
    }

    [HttpPut("{id}")]
    [Authorize]
    [PermissionAuthorize(Permission.EDIT_ORGANISME)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrganismeUpdateFormDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(int id, [FromBody] OrganismeUpdateFormDTO organisme)
    {
        Organisme updatedOrganisme = organisme.ToModel();
        updatedOrganisme.IdOrganisme = id;
        if (this._organismeService.Update(updatedOrganisme))
        {
            return this.Ok();
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete("{id}")]
    [Authorize]
    [PermissionAuthorize(Permission.DELETE_ORGANISME)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrganismeDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(int id)
    {
        try
        {
            return this.Ok(this._organismeService.Delete(id));
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.User_Related;
using PlayZone.API.Mappers.User_Related;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.DAL.Entities.User_Related;
using CompteurWorktimeCategory = PlayZone.BLL.Models.User_Related.CompteurWorktimeCategory;

namespace PlayZone.API.Controllers.User_Related;

[Route("api/[controller]")]
[ApiController]
public class CompteurWorktimeCategoryController : ControllerBase
{
    private readonly ICompteurWorktimeCategoryService _compteurWorktimeCategoryService;

    public CompteurWorktimeCategoryController(ICompteurWorktimeCategoryService compteurWorktimeCategoryService)
    {
        this._compteurWorktimeCategoryService = compteurWorktimeCategoryService;
    }

    [HttpGet]
    [Authorize]
    [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CompteurWorktimeCategoryDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetAll()
    {
        try
        {
            IEnumerable<CompteurWorktimeCategoryDTO> compteurWorktimeCategory =
                this._compteurWorktimeCategoryService.GetAll().Select(cw => cw.ToDTO());
            return this.Ok(compteurWorktimeCategory);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{userId:int}")]
    [Authorize]
    [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CompteurWorktimeCategoryUpdateDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetByUser(int userId)
    {
        try
        {
            IEnumerable<CompteurWorktimeCategoryUpdateDTO> compteurWorktimeCategory = this._compteurWorktimeCategoryService.GetByUser(userId).Select(cw => cw.ToUpdateDTO());
            return this.Ok(compteurWorktimeCategory);
        }
        catch (Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    [Authorize]
    [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Create(CompteurWorktimeCategoryDTO compteurWorktimeCategory)
    {
        try
        {
            CompteurWorktimeCategoryDTO cw = this._compteurWorktimeCategoryService.Create(compteurWorktimeCategory.ToModel()).ToDTO();
            if (compteurWorktimeCategory.UserId == cw.UserId && compteurWorktimeCategory.WorktimeCategoryId == cw.WorktimeCategoryId)
            {
                return this.CreatedAtAction (nameof (this.GetByUser), new { userId = compteurWorktimeCategory.UserId }, cw);
            }
        }
        catch (Exception)
        {
            /* ignored */
        }

        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPut("{userId:int}")]
    [Authorize]
    [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompteurWorktimeCategoryUpdateDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(int userId, [FromBody] CompteurWorktimeCategoryUpdateDTO compteurWorktimeCategory)
    {
        CompteurWorktimeCategory updatedCompteurWorktimeCategory = compteurWorktimeCategory.ToModel();
        updatedCompteurWorktimeCategory.UserId = userId;
        if (this._compteurWorktimeCategoryService.Update(updatedCompteurWorktimeCategory))
        {
            return this.Ok(compteurWorktimeCategory);
        }
        return this.StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete]
    [Authorize]
    [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(CompteurWorktimeCategoryDeleteDTO compteurWorktimeCategory)
    {
        try
        {
            if (this._compteurWorktimeCategoryService.Delete(compteurWorktimeCategory.UserId, compteurWorktimeCategory.WorktimeCategoryId))
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


using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.Worktime_Related;
using PlayZone.API.Mappers.Worktime_Related;
using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.BLL.Models.Worktime_Related;
using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.API.Controllers.Worktime_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorktimeCategoryController : ControllerBase
    {
        private readonly IWorktimeCategoryService _worktimeCategoryService;

        public WorktimeCategoryController(IWorktimeCategoryService worktimeCategoryService)
        {
            this._worktimeCategoryService = worktimeCategoryService;
        }

        [HttpGet]
        [Authorize]
        [PermissionAuthorize([Permission.PERSO_CONSULTER_POINTAGE, Permission.ALL_CONSULTER_POINTAGES])]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WorktimeCategoryDTO>))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<WorktimeCategoryDTO> worktimeCategories =
                    this._worktimeCategoryService.GetAll().Select(w => w.ToDTO());
                return this.Ok(worktimeCategories);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        [PermissionAuthorize([Permission.PERSO_CONSULTER_POINTAGE, Permission.ALL_CONSULTER_POINTAGES])]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorktimeCategoryDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                if (!this.User.HasClaim("Permission", Permission.PERSO_CONSULTER_POINTAGE) &&
                    !this.User.HasClaim("Permission", Permission.ALL_CONSULTER_POINTAGES))
                {
                    return this.StatusCode(StatusCodes.Status403Forbidden);
                }

                WorktimeCategoryDTO? worktimeCategory = this._worktimeCategoryService.GetById(id)?.ToDTO();
                if (worktimeCategory == null)
                {
                    return this.BadRequest("Worktime Category Not Found");
                }

                return this.Ok(worktimeCategory);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Authorize]
        [PermissionAuthorize(Permission.EDIT_WORKTIMECATEGORY)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WorktimeCategoryDTO))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] WorktimeCategoryCreateFormDTO worktimeCategory)
        {
            if (!this.User.HasClaim("Permission", Permission.PERSO_CONSULTER_POINTAGE) &&
                !this.User.HasClaim("Permission", Permission.ALL_CONSULTER_POINTAGES))
            {
                return this.StatusCode(StatusCodes.Status403Forbidden);
            }

            int resultId = this._worktimeCategoryService.Create(worktimeCategory.ToModel());
            if (resultId > 0)
            {
                WorktimeCategoryDTO wc = this._worktimeCategoryService.GetById(resultId)!.ToDTO();
                return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, wc);
            }

            return this.StatusCode(StatusCodes.Status500InternalServerError, resultId);
        }

        [HttpPut("{id}")]
        [Authorize]
        [PermissionAuthorize(Permission.EDIT_WORKTIMECATEGORY)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorktimeCategoryUpdateFormDTO))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, [FromBody] WorktimeCategoryUpdateFormDTO worktimeCategory)
        {
            if (!this.User.HasClaim("Permission", Permission.PERSO_CONSULTER_POINTAGE) &&
                !this.User.HasClaim("Permission", Permission.ALL_CONSULTER_POINTAGES))
            {
                return this.StatusCode(StatusCodes.Status403Forbidden);
            }

            WorktimeCategory updatedWorktimeCategory = worktimeCategory.ToModel();
            updatedWorktimeCategory.IdWorktimeCategory = id;
            if (this._worktimeCategoryService.Update(updatedWorktimeCategory))
            {
                return this.Ok();
            }

            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [PermissionAuthorize(Permission.EDIT_WORKTIMECATEGORY)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorktimeCategoryDTO))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                return this.Ok(this._worktimeCategoryService.Delete(id));
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

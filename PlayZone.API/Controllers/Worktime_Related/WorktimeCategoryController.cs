using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTOs.Worktime_Related;
using PlayZone.API.Mappers.Worktime_Related;
using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.BLL.Models.Worktime_Related;

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

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WorktimeCategoryDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<WorktimeCategoryDTO> worktimeCategories = this._worktimeCategoryService.GetAll().Select(w => w.ToDTO());
                return this.Ok(worktimeCategories);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorktimeCategoryDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(string id)
        {
            try
            {
                WorktimeCategoryDTO worktimeCategory = this._worktimeCategoryService.GetById(id).ToDTO();
                return this.Ok(worktimeCategory);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WorktimeCategoryDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] WorktimeCategoryDTO worktimeCategory)
        {
            string resultId = this._worktimeCategoryService.Create(worktimeCategory.ToModels());
            if (resultId != "")
            {
                return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, worktimeCategory);
            }
            return this.StatusCode(StatusCodes.Status500InternalServerError, resultId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorktimeCategoryUpdateFormDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(string id, [FromBody] WorktimeCategoryUpdateFormDTO worktimeCategory)
        {
            WorktimeCategory updatedWorktimeCategory = worktimeCategory.ToModels();
            updatedWorktimeCategory.IdWorktimeCategory = id;
            if (this._worktimeCategoryService.Update(updatedWorktimeCategory))
            {
                return this.Ok();
            }
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorktimeCategoryDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(string id)
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

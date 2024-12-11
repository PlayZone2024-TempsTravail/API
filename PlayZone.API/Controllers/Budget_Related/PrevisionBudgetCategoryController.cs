using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.Budget_Related;
using PlayZone.API.Mappers.Budget_Related;
using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.DAL.Entities.User_Related;
using Models = PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Controllers.Budget_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrevisionBudgetCategoryController : ControllerBase
    {
        private readonly IPrevisionBudgetCategoryService _pbcs;

        public PrevisionBudgetCategoryController(IPrevisionBudgetCategoryService pbcs)
        {
            this._pbcs = pbcs;
        }

        [HttpGet("project/{projectId:int}")]
        [Authorize]
        [PermissionAuthorize(Permission.SHOW_PROJECTS)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PrevisionBudgetCategoryDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllByProject(int projectId)
        {
            try
            {
                IEnumerable<PrevisionBudgetCategoryDTO> pbcs = this._pbcs.GetByProject(projectId)
                    .Select(pbc => pbc.ToDTO());
                return this.Ok(pbcs);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("id/{id:int}")]
        [Authorize]
        [PermissionAuthorize(Permission.SHOW_PROJECTS)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PrevisionBudgetCategoryDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                PrevisionBudgetCategoryDTO? pbc = this._pbcs.GetById(id)?.ToDTO();
                if (pbc != null)
                    return this.Ok(pbc);
                return this.NotFound();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Authorize]
        [PermissionAuthorize(Permission.EDIT_PREVISION_CATEGORY)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PrevisionBudgetCategoryDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] PrevisionBudgetCategoryCreateDTO pbc)
        {
            try
            {
                int resultId = this._pbcs.Create(pbc.ToModel());
                PrevisionBudgetCategoryDTO pbcDTO = this._pbcs.GetById(resultId)!.ToDTO();
                return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, pbcDTO);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        [Authorize]
        [PermissionAuthorize(Permission.EDIT_PREVISION_CATEGORY)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, [FromBody] PrevisionBudgetCategoryUpdateDTO pbc)
        {
            try
            {
                Models.PrevisionBudgetCategory pbcModel = pbc.ToModel();
                pbcModel.IdPrevisionBudgetCategory = id;

                if (this._pbcs.Update(pbcModel))
                    return this.Ok();
                return this.NotFound();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        [PermissionAuthorize(Permission.DELETE_PREVISION_CATEGORY)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                if (this._pbcs.Delete(id))
                    return this.Ok();
                return this.NotFound();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

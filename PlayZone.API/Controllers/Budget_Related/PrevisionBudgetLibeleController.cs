using Microsoft.AspNetCore.Http;
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
    public class PrevisionBudgetLibeleController : ControllerBase
    {
        private readonly IPrevisionBudgetLibeleService _previsionBudgetLibeleService;

        public PrevisionBudgetLibeleController(IPrevisionBudgetLibeleService _previsionBudgetLibeleService)
        {
            this._previsionBudgetLibeleService = _previsionBudgetLibeleService;
        }

        [HttpGet("project/{projectId:int}")]
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PrevisionBudgetLibeleDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetByProject(int projectId)
        {
            try
            {
                IEnumerable<PrevisionBudgetLibeleDTO> previsionBudgetLibeleServices = this._previsionBudgetLibeleService.GetByIdProject(projectId)
                    .Select(pbc => pbc.ToDTO());
                return this.Ok(previsionBudgetLibeleServices);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("id/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PrevisionBudgetLibeleDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                PrevisionBudgetLibeleDTO? pbc = this._previsionBudgetLibeleService.GetById(id)?.ToDTO();
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
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PrevisionBudgetLibeleDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] PrevisionBudgetLibeleCreateDTO pbl)
        {
            try
            {
                int resultId = this._previsionBudgetLibeleService.Create(pbl.ToModel());
                PrevisionBudgetLibeleDTO pblDTO = this._previsionBudgetLibeleService.GetById(resultId)!.ToDTO();
                return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, pblDTO);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, [FromBody] PrevisionBudgetLibeleUpdateDTO pbl)
        {
            try
            {
                Models.PrevisionBudgetLibele pblModel = pbl.ToModel();
                pblModel.IdPrevisionBudgetLibele = id;

                if (this._previsionBudgetLibeleService.Update(pblModel))
                    return this.Ok();
                return this.NotFound();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                if (this._previsionBudgetLibeleService.Delete(id))
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

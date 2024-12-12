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
    public class DepenseController : ControllerBase
    {
        private readonly IDepenseService _depenseService;

        public DepenseController(IDepenseService depenseService)
        {
            this._depenseService = depenseService;
        }

        [HttpGet("projets/{id}")]
        [Authorize]
        [PermissionAuthorize(Permission.SHOW_PROJECTS)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DepenseDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetByProjectId(int id)
        {
            try
            {
                IEnumerable<DepenseDTO> depenses = this._depenseService.GetByProjectId(id).Select(d => d.ToDTO());

                return this.Ok(depenses);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        [PermissionAuthorize(Permission.SHOW_PROJECTS)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DepenseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                DepenseDTO? depense = this._depenseService.GetById(id)?.ToDTO();
                if (depense == null)
                {
                    return this.BadRequest("Depense Not Found");
                }

                return this.Ok(depense);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Authorize]
        [PermissionAuthorize(Permission.EDIT_DEPENSE)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DepenseDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] CreateDepenseDTO depense)
        {
            int resultId = this._depenseService.Create(depense.ToModel());
            if (resultId > 0)
            {
                DepenseDTO depenses = this._depenseService.GetById(resultId)!.ToDTO();
                return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, depenses);
            }

            return this.StatusCode(StatusCodes.Status500InternalServerError, resultId);
        }

        [HttpPut]
        [Authorize]
        [PermissionAuthorize(Permission.EDIT_DEPENSE)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, [FromBody] UpdateDepenseDTO depense)
        {
            if (id <= 0)
            {
                return this.BadRequest("Invalid Id");
            }

            Models.Depense updatedDepense = depense.ToModel();
            updatedDepense.IdDepense = id;
            if (this._depenseService.Update(updatedDepense))
            {
                return this.Ok();
            }

            return this.StatusCode(StatusCodes.Status500InternalServerError, "Error while updating Depense");
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        [PermissionAuthorize(Permission.DELETE_DEPENSE)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                return this.Ok(this._depenseService.Delete(id));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error while Delete Depense");
            }
        }
    }
}

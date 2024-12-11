using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.Budget_Related;
using PlayZone.API.Mappers.Budget_Related;
using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.API.Controllers.Budget_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibeleController : ControllerBase
    {
        private readonly ILibeleService _libeleService;

        public LibeleController(ILibeleService libeleService)
        {
            this._libeleService = libeleService;
        }

        [HttpGet]
        [Authorize]
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LibeleDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<LibeleDTO> libeles = this._libeleService.GetAll().Select(o => o.ToDTO());
                return this.Ok(libeles);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("tree")]
        [Authorize]
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LibeleDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllWithCategories()
        {
            try
            {
                IEnumerable<TreeCategoryDTO> treeCategories = this._libeleService.GetAllWithCategories().Select(c => c.ToDTO());
                return this.Ok(treeCategories);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id:int}")]
        [Authorize]
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibeleDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                LibeleDTO libele = this._libeleService.GetById(id).ToDTO();
                return this.Ok(libele);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Authorize]
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LibeleCreateFormDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] LibeleCreateFormDTO libele)
        {
            int resultId = this._libeleService.Create(libele.ToModel());
            if (resultId > 0)
            {
                return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, libele);
            }

            return this.StatusCode(StatusCodes.Status500InternalServerError, resultId);
        }

        [HttpPut("{id}")]
        [Authorize]
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibeleUpdateFormDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, [FromBody] LibeleUpdateFormDTO libele)
        {
            Libele updatedLibele = libele.ToModel();
            updatedLibele.IdLibele = id;
            if (this._libeleService.Update(updatedLibele))
            {
                return this.Ok();
            }

            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibeleDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                return this.Ok(this._libeleService.Delete(id));
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

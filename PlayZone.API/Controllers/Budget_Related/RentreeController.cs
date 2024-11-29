using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTOs.Budget_Related;
using PlayZone.API.Mappers.Budget_Related;
using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Controllers.Budget_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentreeController : ControllerBase
    {
        private readonly IRentreeService _rentreeService;

        public RentreeController(IRentreeService rentreeService)
        {
            this._rentreeService = rentreeService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RentreeDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<RentreeDTO> rentrees = this._rentreeService.GetAll().Select(o => o.ToDTO());
                return this.Ok(rentrees);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("idorganisme/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentreeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByProject(int id)
        {
            try
            {
                IEnumerable<RentreeDTO> rentrees = this._rentreeService.GetByProject(id).Select(p => p.ToDTO());
                return this.Ok(rentrees);
            }
            catch (Exception)
            {
                return this.NotFound("Project Not Found");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentreeDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                RentreeDTO rentree = this._rentreeService.GetById(id).ToDTO();
                return this.Ok(rentree);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RentreeCreateFormDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] RentreeCreateFormDTO rentree)
        {
            int resultId = this._rentreeService.Create(rentree.ToModel());
            if (resultId > 0)
            {
                return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, rentree);
            }
            return this.StatusCode(StatusCodes.Status500InternalServerError, resultId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentreeUpdateFormDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(int id, [FromBody] RentreeUpdateFormDTO rentree)
        {
            try
            {
                Rentree updatedRentree = rentree.ToModel();
                updatedRentree.IdRentree = id;
                if (this._rentreeService.Update(updatedRentree))
                {
                    return this.Ok();
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e);
            }
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentreeDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                return this.Ok(this._rentreeService.Delete(id));
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }

}
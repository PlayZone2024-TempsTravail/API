using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.Attributes;
using PlayZone.API.DTOs.Worktime_Related;
using PlayZone.API.Mappers.Worktime_Related;
using PlayZone.BLL.Interfaces.Worktime_Related;
using PlayZone.DAL.Entities.User_Related;

namespace PlayZone.API.Controllers.Worktime_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly ICompteurService _compteurService;
        public CounterController(ICompteurService compteurService)
        {
            this._compteurService = compteurService;
        }

        [HttpGet("absence/{idUser:int}")]
        [Authorize]
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        public IActionResult GetAbsenceByUser(int idUser)
        {
            try
            {
                IEnumerable<CompteurAbsenceDTO> compteurs = this._compteurService.GetCounterOfAbsenceByUser(idUser).Select(c => c.ToDTO());
                return this.Ok(compteurs);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("projet/{idUser:int}")]
        [Authorize]
        [PermissionAuthorize(Permission.DEBUG_PERMISSION)]
        public IActionResult GetProjectByUser(int idUser)
        {
            try
            {
                IEnumerable<CompteurProjetDTO> compteur = this._compteurService.GetCounterOfProjectByUser(idUser).Select(c => c.ToDTO());
                return this.Ok(compteur);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}

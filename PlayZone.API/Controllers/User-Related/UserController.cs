using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayZone.BLL.DTOs.User_Related;
using PlayZone.BLL.Interfaces.User_Related;

namespace PlayZone.API.Controllers.User_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userServices;

        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }
// Delete l'utilisateur
        [HttpDelete("delete/{IdUser:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete( int IdUser)
        {
            try
            {
                // TODO
                // implémenter cette Condision pour vérifier si l'employé(e) est bien dans la base de données ou non.
                // var employeeToDelete = this._userServices.GetById(Id);
                //
                // if (employeeToDelete == null)
                // {
                //     return NotFound($"Employee with Id = {Id} not found");
                // }
                return this.Ok(this._userServices.Delete(IdUser));
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }


    }
}

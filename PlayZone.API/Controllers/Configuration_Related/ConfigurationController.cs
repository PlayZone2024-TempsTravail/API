using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTOs.Configuration_Related;
using PlayZone.API.Mappers.Configuration_Related;
using PlayZone.BLL.Interfaces.Configuration_Related;
using PlayZone.BLL.Models.Configuration_Related;

namespace PlayZone.API.Controllers.Configuration_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            this._configurationService = configurationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<ConfigurationDTO> configurations = this._configurationService.GetAll().Select(c => c.ToDTO());
                return this.Ok(configurations);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                ConfigurationDTO configurations = this._configurationService.GetById(id).ToDTO();
                return this.Ok(configurations);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ConfigurationCreateFormDTO))]
            [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
            public IActionResult Create([FromBody] ConfigurationCreateFormDTO user)
            {
                int resultId = this._configurationService.Create(user.ToModels());
                if (resultId > 0)
                {
                    return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, user);
                }
                return this.StatusCode(StatusCodes.Status500InternalServerError, resultId);
            }

            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public IActionResult Update(int id, [FromBody] ConfigurationDTO configuration)
            {
                if (id <= 0)
                {
                    return this.BadRequest("Invalid user data");
                }

                Configuration updatedConfiguration = configuration.ToModels();
                updatedConfiguration.IdConfiguration = id;
                if (this._configurationService.Update(updatedConfiguration))
                {
                    return this.Ok();
                }
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

            [HttpDelete("{idUser:int}")]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public IActionResult Delete(int idConfiguration)
            {
                try
                {
                    return this.Ok(this._configurationService.Delete(idConfiguration));
                }
                catch (Exception)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
    }
}

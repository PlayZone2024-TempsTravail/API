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
                IEnumerable<ConfigurationDTO> configurations =
                    this._configurationService.GetAll().Select(c => c.ToDTO());
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
        public IActionResult Create([FromBody] ConfigurationCreateFormDTO configuration)
        {
            int resultId = this._configurationService.Create(configuration.ToModels());
            if (resultId > 0)
            {
                return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, configuration);
            }

            return this.StatusCode(StatusCodes.Status500InternalServerError, resultId);
        }
    }
}

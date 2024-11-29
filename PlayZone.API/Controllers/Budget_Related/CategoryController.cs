using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayZone.API.DTOs.Budget_Related;
using PlayZone.API.Mappers.Budget_Related;
using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Controllers.Budget_Related
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<CategoryDTO> categories = this._categoryService.GetAll().Select(c => c.ToDTO());
                return this.Ok(categories);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                CategoryDTO category = this._categoryService.GetById(id).ToDTO();
                return this.Ok(category);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CategoryCreateFormDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult Create([FromBody] CategoryCreateFormDTO category)
        {
            int resultId = this._categoryService.Create(category.ToModels());
            if (resultId > 0)
            {
                return this.CreatedAtAction(nameof(this.GetById), new { id = resultId }, category);
            }
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryUpdateFormDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CategoryUpdateFormDTO category)
        {
            Category updatedCategory = category.ToModels();
            updatedCategory.IdCategory = id;
            if (this._categoryService.Update(updatedCategory))
            {
                return this.Ok(updatedCategory);
            }
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return this.Ok(this._categoryService.Delete(id));
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}

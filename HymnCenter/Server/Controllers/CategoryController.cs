using HymnCenter.Server.Authorization;
using HymnCenter.Server.Models;
using HymnCenter.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HymnCenter.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Returns a list of paginated categories with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetCategories([FromQuery] string? name, int page)
        {
            return Ok(_categoryRepository.GetCategories(name, page));
        }

        /// <summary>
        /// Gets a specific category by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            return Ok(await _categoryRepository.GetCategory(id));
        }
    }
}

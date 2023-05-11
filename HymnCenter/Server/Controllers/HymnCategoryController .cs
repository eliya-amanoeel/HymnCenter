using HymnCenter.Server.Authorization;
using HymnCenter.Server.Models;
using HymnCenter.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HymnCenter.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HymnCategoryController : ControllerBase
    {
        private readonly IHymnCategoryRepository _hymnCategoryRepository;

        public HymnCategoryController(IHymnCategoryRepository hymnCategoryRepository)
        {
            _hymnCategoryRepository = hymnCategoryRepository;
        }

        /// <summary>
        /// Returns a list of paginated categories with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetHymnCategories([FromQuery] string? name, int page)
        {
            return Ok(_hymnCategoryRepository.GetHymnCategories(name, page));
        }

        /// <summary>
        /// Gets a specific category by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetHymnCategory(int id)
        {
            return Ok(await _hymnCategoryRepository.GetHymnCategory(id));
        }

        /// <summary>
        /// Creates a category
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddHymnCategory(HymnCategory hymnCategory)
        {
            return Ok(await _hymnCategoryRepository.AddHymnCategory(hymnCategory));
        }

        /// <summary>
        /// Updates a category with a specific Id.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateHymnCategory(HymnCategory hymnCategory)
        {
            return Ok(await _hymnCategoryRepository.UpdateHymnCategory(hymnCategory));
        }

        /// <summary>
        /// Deletes a category with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHymnCategory(int id)
        {
            return Ok(await _hymnCategoryRepository.DeleteHymnCategory(id));
        }
    }
}

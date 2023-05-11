using HymnCenter.Server.Authorization;
using HymnCenter.Server.Models;
using HymnCenter.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HymnCenter.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HymnController : ControllerBase
    {
        private readonly IHymnRepository _hymnRepository;

        public HymnController(IHymnRepository hymnRepository)
        {
            _hymnRepository = hymnRepository;
        }

        /// <summary>
        /// Returns a list of paginated hymns with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetHymns([FromQuery] string? name, int page, int? categoryId)
        {
            if(categoryId == null)
            {
                return GetAll(name, page);
            }
            else
            {
                return GetByCategory(categoryId, page);
            }            
        }

        public ActionResult GetAll(string name, int page)
        {
            return Ok(_hymnRepository.GetHymns(name, page));
        }

        public ActionResult GetByCategory(int? categoryId, int page)
        {
            return Ok(_hymnRepository.GetHymnsByCategory(categoryId, page));
        }

        /// <summary>
        /// Gets a specific hymn by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetHymn(int id)
        {
            return Ok(await _hymnRepository.GetHymn(id));
        }

        /// <summary>
        /// Creates a hymn
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddHymn(Hymn hymn)
        {
            return Ok(await _hymnRepository.AddHymn(hymn));
        }

        /// <summary>
        /// Updates a hymn with a specific Id.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateHymn(Hymn hymn)
        {
            return Ok(await _hymnRepository.UpdateHymn(hymn));
        }

        /// <summary>
        /// Deletes a hymn with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHymn(int id)
        {
            return Ok(await _hymnRepository.DeleteHymn(id));
        }
    }
}

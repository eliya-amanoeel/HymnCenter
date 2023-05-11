using HymnCenter.Server.Authorization;
using HymnCenter.Server.Models;
using HymnCenter.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HymnCenter.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ListingController : ControllerBase
    {
        private readonly IListingRepository _listingRepository;

        public ListingController(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }

        /// <summary>
        /// Returns a list of paginated hymns with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetListings([FromQuery] string? name, int page)
        {
            return Ok(_listingRepository.GetListings(name, page));
        }

        /// <summary>
        /// Gets a specific listing by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetListing(int id)
        {
            return Ok(await _listingRepository.GetListing(id));
        }

        /// <summary>
        /// Creates a listing with child hymns.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddListing(Listing listing)
        {
            return Ok(await _listingRepository.AddListing(listing));
        }

        /// <summary>
        /// Updates a listing with a specific Id.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateListing(Listing listing)
        {
            return Ok(await _listingRepository.UpdateListing(listing));
        }

        /// <summary>
        /// Deletes a listing with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteListing(int id)
        {
            return Ok(await _listingRepository.DeleteListing(id));
        }
    }
}

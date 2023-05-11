using HymnCenter.Client.Shared;
using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;

namespace HymnCenter.Client.Services
{
    public class ListingService : IListingService
    {
        private IHttpService _httpService;

        public ListingService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<PagedResult<Listing>> GetListings(string? name, string page)
        {
            return await _httpService.Get<PagedResult<Listing>>("api/listing" + "?page=" + page + "&name=" + name);
        }

        public async Task<Listing> GetListing(int id)
        {
            return await _httpService.Get<Listing>($"api/listing/{id}");
        }

        public async Task DeleteListing(int id)
        {
            await _httpService.Delete($"api/listing/{id}");
        }

        public async Task AddListing(Listing listing)
        {
            await _httpService.Post($"api/listing", listing);
        }

        public async Task UpdateListing(Listing listing)
        {
            await _httpService.Put($"api/listing", listing);
        }
    }
}
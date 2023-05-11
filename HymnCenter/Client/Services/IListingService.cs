using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;

namespace HymnCenter.Client.Services
{
    public interface IListingService
    {
        Task<PagedResult<Listing>> GetListings(string? name, string page);
        Task<Listing> GetListing(int id);

        Task DeleteListing(int id);

        Task AddListing(Listing listing);

        Task UpdateListing(Listing listing);
    }
}
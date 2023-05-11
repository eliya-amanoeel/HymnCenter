using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;

namespace HymnCenter.Server.Models
{
    public interface IListingRepository
    {
        PagedResult<Listing> GetListings(string? name, int page);
        Task<Listing?> GetListing(int listingId);
        Task<Listing> AddListing(Listing listing);
        Task<Listing?> UpdateListing(Listing listing);
        Task<Listing?> DeleteListing(int listingId);
    }
}

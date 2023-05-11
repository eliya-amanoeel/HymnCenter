using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HymnCenter.Server.Models
{
    public class ListingRepository : IListingRepository
    {
        private readonly AppDbContext _appDbContext;

        public ListingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Listing> AddListing(Listing listing)
        {
            //var hymns = listing.Hymns;
            //listing.Hymns = new List<Hymn>();
            var result = await _appDbContext.Listings.AddAsync(listing);
            //_appDbContext.SaveChanges();
            //foreach (var h in hymns) { listing.Hymns.Add(h); }
            _appDbContext.SaveChanges();
            return result.Entity;
        }

        public async Task<Listing?> DeleteListing(int listingId)
        {
            var result = await _appDbContext.Listings.FirstOrDefaultAsync(p => p.ListingId == listingId);
            if (result != null)
            {
                _appDbContext.Listings.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Listing not found");
            }
            return result;
        }

        public async Task<Listing?> GetListing(int listingId)
        {
            var result = await _appDbContext.Listings
                .Include(h => h.Hymns)
                .FirstOrDefaultAsync(p => p.ListingId == listingId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Listing not found");
            }
        }

        public PagedResult<Listing> GetListings(string? name, int page)
        {
            int pageSize = 5;

            if (name != null)
            {
                return _appDbContext.Listings
                    .Where(p => p.Header.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(p => p.ListingId)
                    .Include(h => h.Hymns)
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _appDbContext.Listings
                    .OrderBy(p => p.ListingId)
                    .Include(h => h.Hymns)
                    .GetPaged(page, pageSize);
            }
        }

        public async Task<Listing?> UpdateListing(Listing listing)
        {
            var result = await _appDbContext.Listings.FirstOrDefaultAsync(p => p.ListingId == listing.ListingId);
            if (result != null)
            {
                // Update existing listing
                _appDbContext.Entry(result).CurrentValues.SetValues(listing);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Listing not found");
            }
            return result;
        }
    }
}
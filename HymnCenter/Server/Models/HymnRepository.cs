using HymnCenter.Server.Helpers;
using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HymnCenter.Server.Models
{
    public class HymnRepository : IHymnRepository
    {
        private readonly AppDbContext _appDbContext;

        public HymnRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Hymn> AddHymn(Hymn hymn)
        {
            var categories = hymn.Categories;
            hymn.Categories = new List<Category>();
            var result = await _appDbContext.Hymns.AddAsync(hymn);
            await _appDbContext.SaveChangesAsync();
            foreach (var c in categories) { hymn.Categories.Add(c); }
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Hymn?> DeleteHymn(int hymnId)
        {
            var result = await _appDbContext.Hymns.FirstOrDefaultAsync(p => p.HymnId==hymnId);
            if (result!=null)
            {
                _appDbContext.Hymns.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Hymn not found");
            }
            return result;
        }

        public async Task<Hymn?> GetHymn(int hymnId)
        {
            var result = await _appDbContext.Hymns
                .Include(c => c.Categories)
                .FirstOrDefaultAsync(p => p.HymnId==hymnId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Hymn not found");
            }
        }

        public PagedResult<Hymn> GetHymns(string? name, int page)
        {
            int pageSize = 5;

            if (name != null)
            {
                return _appDbContext.Hymns
                    .Where(p => p.Title.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(p => p.HymnId)
                    .Include(c => c.Categories)
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _appDbContext.Hymns
                    .OrderBy(p => p.HymnId)
                    .Include(c => c.Categories)
                    .GetPaged(page, pageSize);
            }
        }

        public PagedResult<Hymn> GetHymnsByCategory(int? categoryId, int page)
        {
            int pageSize = 5;

            if (categoryId != 0)
            {
                //var result = 
                //    from h in _appDbContext.Hymns
                //    from c in h.Categories
                //    where c.CategoryId == categoryId
                //    select h;
                //return result
                //    .OrderBy(p => p.HymnId)
                //    .GetPaged(page, pageSize);

                return _appDbContext.Hymns
                    .Where(p => p.Categories
                    .Any(c => c.CategoryId == categoryId))
                    .OrderBy(p => p.HymnId)
                    .GetPaged(page, pageSize);
            }
            else
            {
                return null;
            }
        }

        public async Task<Hymn?> UpdateHymn(Hymn updatedHymn)
        {
            var existingHymn = await _appDbContext.Hymns
                .Include(c => c.Categories)
                .FirstOrDefaultAsync(p => p.HymnId == updatedHymn.HymnId);

            if (existingHymn != null)
            {
                ICollection<Category> removedCategories = existingHymn.Categories
                    .Except(updatedHymn.Categories, ProjectionEqualityComparer<Category>
                    .Create(a => a.CategoryId))
                    .ToList();

                HashSet<int> categoryIds = new HashSet<int>(removedCategories.Select(x => x.CategoryId));

                foreach (Category updatedCat in updatedHymn.Categories)
                {                    
                    existingHymn.Categories.Add(updatedCat);
                }
                existingHymn.Categories = existingHymn.Categories
                    .GroupBy(x => x.CategoryId)
                    .Select(y => y
                    .First())
                    .Where(x => categoryIds
                    .Contains(x.CategoryId) == false)
                    .ToList();

                _appDbContext.Entry(existingHymn).CurrentValues.SetValues(updatedHymn);
                _appDbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Hymn not found");
            }
            return existingHymn;
        }
    }
}
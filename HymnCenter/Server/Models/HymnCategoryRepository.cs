using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HymnCenter.Server.Models
{
    public class HymnCategoryRepository : IHymnCategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public HymnCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<HymnCategory?> GetHymnCategory(int hymnCategoryId)
        {
            var result = await _appDbContext.HymnCategories
               .FirstOrDefaultAsync(p => p.CategoryId==hymnCategoryId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("HymnCategory not found");
            }
        }

        public ICollection<HymnCategory> GetHymnCategories(string? name, int page)
        {            
            if (name != null)
            {
                return _appDbContext.HymnCategories
                    .OrderBy(p => p.CategoryId)
                    .ToList();
            }
            else
            {
                return _appDbContext.HymnCategories
                    .OrderBy(p => p.CategoryId)
                    .ToList();
            }
        }

        public async Task<HymnCategory> AddHymnCategory(HymnCategory hymnCategory)
        {
            var result = await _appDbContext.HymnCategories.AddAsync(hymnCategory);
            //await _appDbContext.SaveChangesAsync();
            _appDbContext.SaveChanges();
            return result.Entity;
        }

        public async Task<HymnCategory?> DeleteHymnCategory(int hymnCategoryId)
        {
            var result = await _appDbContext.HymnCategories
                .FirstOrDefaultAsync(p => p.CategoryId == hymnCategoryId);
            if (result != null)
            {
                _appDbContext.HymnCategories.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("HymnCategory not found");
            }
            return result;
        }

        public async Task<HymnCategory?> UpdateHymnCategory(HymnCategory hymnCategory)
        {
            var result = await _appDbContext.HymnCategories
                .FirstOrDefaultAsync(p => p.CategoryId == hymnCategory.CategoryId);
            if (result != null)
            {
                // Update existing category
                _appDbContext.Entry(result).CurrentValues.SetValues(hymnCategory);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("HymnCategory not found");
            }
            return result;
        }
    }
}
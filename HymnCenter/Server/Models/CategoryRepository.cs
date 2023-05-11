using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HymnCenter.Server.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Category?> GetCategory(int categoryId)
        {
            var result = await _appDbContext.Categories
                .FindAsync(categoryId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Category not found");
            }
        }

        public ICollection<Category> GetCategories(string? name, int page)
        {            
            if (name != null)
            {
                return _appDbContext.Categories
                    .OrderBy(p => p.CategoryId)
                    .ToList();
            }
            else
            {
                return _appDbContext.Categories
                    .OrderBy(p => p.CategoryId)
                    .ToList();
            }
        }
    }
}
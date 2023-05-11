using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;

namespace HymnCenter.Server.Models
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories(string? name, int page);
        Task<Category?> GetCategory(int categoryId);
    }
}
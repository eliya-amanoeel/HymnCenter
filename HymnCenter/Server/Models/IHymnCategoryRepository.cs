using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;

namespace HymnCenter.Server.Models
{
    public interface IHymnCategoryRepository
    {
        ICollection<HymnCategory> GetHymnCategories(string? name, int page);
        Task<HymnCategory?> GetHymnCategory(int hymnCategoryId);
        Task<HymnCategory> AddHymnCategory(HymnCategory hymnCategory);
        Task<HymnCategory?> UpdateHymnCategory(HymnCategory hymnCategory);
        Task<HymnCategory?> DeleteHymnCategory(int hymnCategory);
    }
}
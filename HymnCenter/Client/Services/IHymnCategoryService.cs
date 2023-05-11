using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;

namespace HymnCenter.Client.Services
{
    public interface IHymnCategoryService
    {
        Task<PagedResult<HymnCategory>> GetHymnCategories(string? name, string page);

        Task<HymnCategory> GetHymnCategory(int id);

        Task DeleteHymnCategory(int id);

        Task AddHymnCategory(HymnCategory hymnCategory);

        Task UpdateHymnCategory(HymnCategory hymnCategory);
    }
}
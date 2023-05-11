using HymnCenter.Client.Shared;
using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;

namespace HymnCenter.Client.Services
{
    public class HymnCategoryService : IHymnCategoryService
    {
        private IHttpService _httpService;

        public HymnCategoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<PagedResult<HymnCategory>> GetHymnCategories(string? name, string page)
        {
            return await _httpService.Get<PagedResult<HymnCategory>>("api/hymncategory" + "?page=" + page + "&name=" + name);
        }

        public async Task<HymnCategory> GetHymnCategory(int id)
        {
            return await _httpService.Get<HymnCategory>($"api/hymncategory/{id}");
        }

        public async Task DeleteHymnCategory(int id)
        {
            await _httpService.Delete($"api/hymncategory/{id}");
        }

        public async Task AddHymnCategory(HymnCategory hymnCategory)
        {
            await _httpService.Post($"api/hymncategory", hymnCategory);
        }

        public async Task UpdateHymnCategory(HymnCategory hymnCategory)
        {
            await _httpService.Put($"api/hymncategory", hymnCategory);
        }
    }
}
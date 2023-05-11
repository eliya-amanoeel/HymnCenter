using HymnCenter.Client.Shared;
using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;
using System.Collections.Generic;

namespace HymnCenter.Client.Services
{
    public class CategoryService: ICategoryService
    {
        private IHttpService _httpService;

        public CategoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ICollection<Category>> GetCategories(string? name, string page)
        {
            return await _httpService.Get<ICollection<Category>>("api/category" + "?page=" + page + "&name=" + name);
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _httpService.Get<Category>($"api/category/{id}");
        }
    }
}
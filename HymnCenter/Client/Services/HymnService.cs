using HymnCenter.Client.Shared;
using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;

namespace HymnCenter.Client.Services
{
    public class HymnService : IHymnService
    {
        private IHttpService _httpService;

        public HymnService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<PagedResult<Hymn>> GetHymns(string? name, string page, int? categoryId)
        {
            if(categoryId == null)
            {
                return await _httpService.Get<PagedResult<Hymn>>("api/hymn" + "?page=" + page + "&name=" + name);
            }
            else
            {
                return await _httpService.Get<PagedResult<Hymn>>("api/hymn" + "?page=" + page + "&categoryId=" + categoryId);
            }
        }

        public async Task<Hymn> GetHymn(int id)
        {
            return await _httpService.Get<Hymn>($"api/hymn/{id}");
        }

        public async Task DeleteHymn(int id)
        {
            await _httpService.Delete($"api/hymn/{id}");
        }

        public async Task AddHymn(Hymn hymn)
        {
            await _httpService.Post($"api/hymn", hymn);
        }

        public async Task UpdateHymn(Hymn hymn)
        {
            await _httpService.Put($"api/hymn", hymn);
        }
    }
}
using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;

namespace HymnCenter.Client.Services
{
    public interface IHymnService
    {
        Task<PagedResult<Hymn>> GetHymns(string? name, string page, int? categoryId);

        Task<Hymn> GetHymn(int id);

        Task DeleteHymn(int id);

        Task AddHymn(Hymn hymn);

        Task UpdateHymn(Hymn hymn);
    }
}
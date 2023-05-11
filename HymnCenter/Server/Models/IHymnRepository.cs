using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;

namespace HymnCenter.Server.Models
{
    public interface IHymnRepository
    {
        PagedResult<Hymn> GetHymns(string? name, int page);
        PagedResult<Hymn> GetHymnsByCategory(int? categoryId, int page);
        Task<Hymn?> GetHymn(int hymnId);
        Task<Hymn> AddHymn(Hymn hymn);
        Task<Hymn?> UpdateHymn(Hymn hymn);
        Task<Hymn?> DeleteHymn(int hymnId);
    }
}
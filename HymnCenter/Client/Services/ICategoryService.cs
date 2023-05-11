using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;
using System.Collections.Generic;

namespace HymnCenter.Client.Services
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetCategories(string? name, string page);
        Task<Category> GetCategory(int id);
    }
}
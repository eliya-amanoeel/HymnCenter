using HymnCenter.Client.Shared;
using HymnCenter.Shared.Data;
using HymnCenter.Shared.Models;

namespace HymnCenter.Client.Services
{
    public interface IUserService
    {
        User User {get; }
        Task Initialize();
        Task Login(Login model);
        Task Logout();
        Task<PagedResult<User>> GetUsers(string? name, string page);
        Task<User> GetUser(int id);
        Task DeleteUser(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
    }
}
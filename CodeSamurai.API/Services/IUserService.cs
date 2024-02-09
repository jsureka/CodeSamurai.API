using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;

namespace CodeSamurai.API.Services
{
    public interface IUserService
    {
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(int id, User updatedUser);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> SearchUsersAsync(QueryParameters queryParams);
    }
}

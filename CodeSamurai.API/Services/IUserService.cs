using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;

namespace CodeSamurai.API.Services
{
    public interface IUserService
    {
        Task<User> AddUserAsync(User book);
        Task<User> UpdateUserAsync(int id, User updatedBook);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> SearchUsersAsync(QueryParameters queryParams);
    }
}

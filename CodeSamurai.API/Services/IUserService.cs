using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;

namespace CodeSamurai.API.Services
{
    public interface IUserService
    {
        void AddUserAsync(User user);
        void UpdateUserAsync(int id, User updatedUser);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> SearchUsersAsync(QueryParameters queryParams);
    }
}

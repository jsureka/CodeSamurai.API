using CodeSamurai.API.Core.Domains;
using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;

namespace CodeSamurai.API.Services
{
    public interface IBookService
    {
        Task<User> AddBookAsync(User book);
        Task<User> UpdateBookAsync(int id, User updatedBook);
        Task<IEnumerable<User>> GetAllBooksAsync();
        Task<User> GetBookByIdAsync(int id);
        Task<IEnumerable<User>> SearchBooksAsync(QueryParameters queryParams);
    }
}

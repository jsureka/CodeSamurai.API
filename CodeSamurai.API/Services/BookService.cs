using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeSamurai.API.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public BookService(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            await _bookRepository.Add(book);
            return book;
        }

        public async Task<Book> UpdateBookAsync(int id, Book updatedBook)
        {
            var existingBook = await _bookRepository.GetById(id);
            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.Genre = updatedBook.Genre;
                // Update other properties as needed
                await _bookRepository.Update(existingBook);
                return existingBook;
            }
            return null; // Book not found
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetById(id);
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(QueryParameters queryParams)
        {
            var query = _bookRepository.Queryable();
            if (!string.IsNullOrEmpty(queryParams.Title))
            {
                query = query.Where(b => b.Title.Contains(queryParams.Title));
            }
            if (!string.IsNullOrEmpty(queryParams.Author))
            {
                query = query.Where(b => b.Author.Contains(queryParams.Author));
            }
            if (!string.IsNullOrEmpty(queryParams.Genre))
            {
                query = query.Where(b => b.Genre.Contains(queryParams.Genre));
            }

            return await query.ToListAsync();
        }
    }
}

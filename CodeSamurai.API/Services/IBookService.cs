﻿using CodeSamurai.API.Core.Domains;
using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;

namespace CodeSamurai.API.Services
{
    public interface IBookService
    {
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(int id, Book updatedBook);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> SearchBooksAsync(QueryParameters queryParams);
    }
}

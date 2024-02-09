using AutoMapper;
using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeSamurai.API.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;

        public UserService(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public void AddUserAsync(User user)
        {
            _repository.Add(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _repository.Queryable().FirstOrDefaultAsync(u => u.User_id == id);

        }

        public Task<IEnumerable<User>> SearchUsersAsync(QueryParameters queryParams)
        {
            throw new NotImplementedException();
        }

        public async void UpdateUserAsync(int id, User updatedUser)
        {
            var user = await _repository.GetById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            updatedUser.Id = id;
            await _repository.Update(updatedUser);
        }
    }
}

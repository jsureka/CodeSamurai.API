using CodeSamurai.API.Core.Framework;
using CodeSamurai.API.Entities;
using CodeSamurai.API.Models;
using CodeSamurai.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CodeSamurai.API.Controllers
{
    [Route("api/users")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User User)
        {
            try
            {
                var addedUser = await _userService.AddUserAsync(User);
                return Created(nameof(addedUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        {
            try
            {
                var User = await _userService.UpdateUserAsync(id, updatedUser);
                return Ok(User);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchUsersAsync([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var Users = await _userService.SearchUsersAsync(queryParameters);
                if (Users == null)
                {
                    return NotFound();
                }
                var responseModel = new ResponseListModel<User>
                {
                    Data = Users.ToList(),
                };

                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

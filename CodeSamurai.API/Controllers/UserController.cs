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
        public IActionResult AddUser(UserModel userModel)
        {
            var user = new User
            {
                Name = userModel.User_name,
                Balance = userModel.Balance,
                User_id = userModel.User_id
            };
            try
            {
                _userService.AddUserAsync(user);
                var addedUser = new UserModel
                {
                    User_id = user.User_id,
                    User_name = user.Name,
                    Balance = user.Balance
                };

                return Created(addedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

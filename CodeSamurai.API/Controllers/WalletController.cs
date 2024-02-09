using CodeSamurai.API.Core.Framework;
using CodeSamurai.API.Models;
using CodeSamurai.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeSamurai.API.Controllers
{
    [Route("api/wallets")]
    public class WalletController : BaseApiController
    {
        private readonly IUserService _userService;

        public WalletController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWallet(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if(user == null)
                {
                    return StatusCode(404, new ErrorResponseModel
                    {
                        Message = "wallet with id: " + id + " not found"
                    });
                }
                var wallet = new WalletModel
                {
                    Wallet_Id = user.User_id,
                    Balance = user.Balance,
                    Wallet_User = new WalletUserModel
                    {
                        User_id = user.User_id,
                        User_name = user.Name
                    }
                };
                return Ok(wallet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWallet(int id, [FromBody]RechargeModel rechargeModel)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return StatusCode(404, new ErrorResponseModel
                    {
                        Message = "wallet with id: " + id + " not found"
                    });
                }
                if(rechargeModel.Recharge < 100 || rechargeModel.Recharge > 10000)
                {
                    return BadRequest(new ErrorResponseModel
                    {
                        Message = "invalid amount: " + rechargeModel.Recharge
                    });
                }
                user.Balance += rechargeModel.Recharge;
                _userService.UpdateUserAsync(id, user);
                return Ok(new WalletModel
                {
                    Wallet_Id = user.User_id,
                    Balance = user.Balance,
                    Wallet_User = new WalletUserModel
                    {
                        User_id = user.User_id,
                        User_name = user.Name
                    }
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }   
    }
}

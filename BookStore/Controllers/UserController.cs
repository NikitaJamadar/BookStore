using BusinessLayer.Interfaces;
using DataBaseLayer;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
       
          public IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost("Register")]
        public IActionResult AddUser(UserModel userRegistration)
        {
            try
            {
                var user = this.userBL.Register(userRegistration);
                if (user != null)
                {
                    return this.Ok(new { Success = true, message = "User Added Sucessfully", Response = user });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "User not Added " });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPost("login")]
        public IActionResult Login(string Email, string Password)
        {
            try
            {
                var result = this.userBL.Login(Email, Password);
                if (result != null)
                    return this.Ok(new { success = true, message = "Login Successful", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Login UnSuccessful", data = result });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

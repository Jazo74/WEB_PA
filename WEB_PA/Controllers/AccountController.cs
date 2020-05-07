using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using WEB_PA;
using WEB_PA.Domain;
using WEB_PA.Models;
using WEB_PA.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AskMate2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService = new UserHandler();
        IDataService ds = new DBService();

        [HttpGet] 
        public IActionResult Login()
        {
            string currentUser = "";
            currentUser = ds.GetNickname(HttpContext.User.FindFirstValue(ClaimTypes.Email));
            ViewData.Add("currentUser", currentUser);
            return View("Login");
        }
        
      
        [HttpPost]
        public async Task<ActionResult> Login([FromForm] string email, [FromForm] string password)
        {
            //List<User> allUsers = userService.GetAllUsers();

            string Password = userService.GetPasswordByEmail(email);
            
            if (Password == null || Password != password)
            {
                return RedirectToAction("Login", "Account");
            }


            var claims = new List<Claim> { new Claim(ClaimTypes.Email, email) };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Logout()
        {
            return View("Logout");
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Logout([FromForm] string hidden)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Register([FromForm] string nickName, [FromForm] string email, [FromForm] string password, [FromForm] string firstName, [FromForm] string familyName)
        {
            User user = new User(nickName, email, password, firstName, familyName);
            userService.RegisterUser(user);

            return RedirectToAction("Index", "Home");
        }

    }
}
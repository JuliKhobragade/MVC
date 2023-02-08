using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using RampUpAssignment1.Models;

namespace RampUpAssignment1.Controllers
{
    public class AccessController : Controller
    {
       public IActionResult Index1()
        {
            return View();
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Employee");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLogin modelLogin)
        {
            if(modelLogin.Email=="admin@gmail.com" && modelLogin.Password=="admin123")
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,modelLogin.Email),
                    new Claim("OtherPrperties","Example Role"),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);



                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Employee");
            }



            ViewData["ValidateMessage"] = "User not found";
            return View();
        }




    }
}

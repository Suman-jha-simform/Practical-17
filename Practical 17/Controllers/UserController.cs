using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Practical_17.Interfaces;
using Practical_17.Models;
using System.Security.Claims;
using System.Security.Principal;

namespace Practical_17.Controllers
{
    public class UserController : Controller
    {
        private readonly Iuser _user;

        public UserController(Iuser user)
        {
            _user = user;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Register(Users user)
        {
            if(ModelState.IsValid)
            {
                var userInDb = _user.GetUser(user.EmailAddress);
                if(userInDb != null)
                {
                    ModelState.AddModelError("", "This email has been already taken , try a different one.");
                    return View(user);
                }
                else
                {
                    var roleUser = new Roles
                    {
                        EmailAddress = user.EmailAddress,
                        Role = "Member"
                    };
                    bool status = _user.AddUser(user, roleUser);
                    if (status)
                    {
                        return RedirectToAction("Login", "User");
                    }
                } 
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = _user.GetUser(userLogin.EmailAddress);
                var role = _user.GetUserRole(userLogin.EmailAddress);
                if (user == null)
                {
                    ModelState.AddModelError("","Incorrect email or password");
                    return View(userLogin);
                }
                else
                {
                    if (user.Password == userLogin.Password)
                    {

                        var claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name, userLogin.EmailAddress),
                            new Claim(ClaimTypes.Role, role),
                        };

                        var identity = new ClaimsIdentity(claims,  CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Email", user.EmailAddress);
                        return RedirectToAction("Dashboard", "Student");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect email or password");
                        return View(userLogin);
                    }
                }
            }
            else
            {
                return View(userLogin);
            }
        }

        public IActionResult Logout()
        {
            var storedCookies = Request.Cookies.Keys;
            foreach (var cookie in storedCookies)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }
    }
}

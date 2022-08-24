using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using JobBoardStep.Core.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobBoardStepNew.path.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserRepositroy repo;

        public AdminController(IUserRepositroy repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) 
        {
            var user = await repo.UserReturn(model);
            if (user == null)
                return null;

            var verif = await repo.VerifyPassword(model.Password, user.PasswordHash, user.PasswordSalt);
            if (!verif)
                return null;

            HttpSiginAsync(user);

            return RedirectToAction("Index", "Home");
        }
        private void HttpSiginAsync(User user)
        {
            var clamis = new List<Claim>();
            clamis.Add(new Claim(ClaimTypes.Name, user.Email));
            clamis.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var item in repo.gets())
            {

                if (user.Email == item.UserName)
                {
                    clamis.Add(new Claim(ClaimTypes.Role, "Superadmin"));
                    clamis.Add(new Claim(ClaimTypes.Role, "Admin"));
                    clamis.Add(new Claim(ClaimTypes.Role, "User"));
                }

            }
            foreach (var item in repo.getss())
            {

                if (user.Email == item.UserName)
                {
                    clamis.Add(new Claim(ClaimTypes.Role, "Admin"));
                    clamis.Add(new Claim(ClaimTypes.Role, "User"));
                }

            }

            var claimsIdentity = new ClaimsIdentity(clamis,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrinsipal = new ClaimsPrincipal(claimsIdentity);



            HttpContext.SignInAsync(claimsPrinsipal);
        }
    }
}

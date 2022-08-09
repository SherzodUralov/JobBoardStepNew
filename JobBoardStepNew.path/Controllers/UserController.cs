using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using JobBoardStep.Core.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace JobBoardStepNew.path.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepositroy repo;

        public UserController(IUserRepositroy repo)
        {
            this.repo = repo;
        }
        public ViewResult List()
        {
            var model = repo.UserList();

            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }
        [HttpGet]
        public ViewResult Denied()
        {
            return View();
        }

        [HttpGet("Login")]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await repo.UserReturn(model);
            if (user == null)
                return null;

            var verif = await repo.VerifyPassword(model.Password, user.PasswordHash, user.PasswordSalt);
            if (!verif)
                return null;

            HttpSiginAsync(user);

            return RedirectToAction("Index", "Account");

        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.region = new SelectList(repo.RegionList(), "Id", "Name");

            ViewBag.infor = new SelectList(repo.InfroList(), "Id", "Name");

            ViewBag.usertype = new SelectList(repo.UserTypeList(), "UserTypeId", "UserTypeName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(UserCreateViewModel userCreate)
        {
            if (ModelState.IsValid)
            {
                var newuser = repo.NewUser(userCreate);

                repo.Create(newuser);

                return RedirectToAction("List");
            }
            ViewBag.region = new SelectList(repo.RegionList(), "Id", "Name");

            ViewBag.infor = new SelectList(repo.InfroList(), "Id", "Name");

            ViewBag.usertype = new SelectList(repo.UserTypeList(), "UserTypeId", "UserTypeName");
            return View(); 
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            var model = repo.GetById(id);

            var newuser = repo.UpdateUser(model);

            ViewBag.region = new SelectList(repo.RegionList(), "Id", "Name");

            ViewBag.infor = new SelectList(repo.InfroList(), "Id", "Name");

            ViewBag.usertype = new SelectList(repo.UserTypeList(), "UserTypeId", "UserTypeName");

            return View(newuser);
        }
//<<<<<<< HEAD

//=======
//>>>>>>> 44137601c534052559f769555f5979de664b0b0a
        [HttpPost]
        public IActionResult Edit(UserEditViewModel user)
        {
            User exsitnguser = repo.GetById(user.UserId);

            var model = repo.ExsingUser(exsitnguser, user);

            repo.Update(model);

            return RedirectToAction("List");
        }
        public IActionResult Delete(int id) 
        {
            repo.Delete(id);

            return RedirectToAction("List");
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

using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using JobBoardStep.Core.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace JobBoardStepNew.path.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepositroy repo;
        private readonly IWebHostEnvironment webHost;

        public UserController(IUserRepositroy repo, IWebHostEnvironment webHost)
        {
            this.repo = repo;

            this.webHost = webHost;
        }
        [HttpGet]
        public ViewResult ChangePassword() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangeModel model)
        {
            var user = await repo.changereturn(model);
            if (user == null)
                return null;


            var verif = await repo.VerifyPassword(model.OldPassword, user.PasswordHash, user.PasswordSalt);
            if (!verif)
                return null;

            var changeupdate = await repo.CreateChangeAsync(user,model);

            repo.Update(changeupdate);

            return RedirectToAction("List");
        }
        [Authorize(Roles = "Superadmin, admin")]
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

            return RedirectToAction("List");

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
                string UniqueFileName = ProccsesUploadFolder(userCreate);

                var newuser = repo.NewUser(UniqueFileName,userCreate);

                HttpSiginAsyncreg(newuser);

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

        private string ProccsesUploadFolder(UserCreateViewModel user) 
        {
            string uniqueFileName = string.Empty;

            if (user.PhotoFile != null)
            {
                string uploadfolder = Path.Combine(webHost.WebRootPath, "Images");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + user.PhotoFile.Name;

                string imageFilePath = Path.Combine(uploadfolder, uniqueFileName);

                user.PhotoFile.CopyTo(new FileStream(imageFilePath, FileMode.Create));
            }
            return uniqueFileName;
        }
        private void HttpSiginAsyncreg(User model)
        {
            var clamis = new List<Claim>();
            clamis.Add(new Claim(ClaimTypes.Name, model.Email));
            clamis.Add(new Claim(ClaimTypes.NameIdentifier, model.Email));

            var claimsIdentity = new ClaimsIdentity(clamis,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrinsipal = new ClaimsPrincipal(claimsIdentity);

            HttpContext.SignInAsync(claimsPrinsipal);
        }
    }

}

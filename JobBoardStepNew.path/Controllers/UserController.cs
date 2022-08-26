using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using JobBoardStep.Core.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
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
        public ViewResult List(int pg = 1, string searchString  = "")
        {
            
            var modelsession = HttpContext.Session.GetString("language");
            var model = repo.UserList(modelsession);
            ViewData["CurrentFilter"] = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.FirstName.Contains(searchString.ToUpper())).ToList();
            }
            const int pageSize = 5;
            if (pg < 1)
                pg = 1;
            int recsCount = model.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var madel = model.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
        
            return View(madel);
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

            return RedirectToAction("Create","App");

        }
        public string ism;
        [HttpGet]
        public ViewResult Create()
        {
            var model = HttpContext.Session.GetString("language");

            ViewBag.region = new SelectList(repo.RegionList(), "Id", "Name");

            ViewBag.infor = new SelectList(repo.InfroList(model), "Id", "Name");

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

            ViewBag.infor = new SelectList(repo.InfroList(ism), "Id", "Name");

            ViewBag.usertype = new SelectList(repo.UserTypeList(), "UserTypeId", "UserTypeName");
            return View(); 
        }
        //Language
        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(1)});
            HttpContext.Session.SetString("language", culture);


            return LocalRedirect(returnUrl);

           
        }
        
        [HttpGet]
        public ViewResult Edit(int id)
        {
            var model = repo.GetById(id);

            var newuser = repo.UpdateUser(model);

            ViewBag.region = new SelectList(repo.RegionList(), "Id", "Name");

            ViewBag.infor = new SelectList(repo.InfroList(ism), "Id", "Name");

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
        [HttpGet]
        public ViewResult Regestir() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Regestir(RegestirViewModel model) 
        {
            if (ModelState.IsValid)
            {
                 var newuser = repo.NewUser1(model);

                HttpSiginAsyncreg1(newuser);

                repo.Create(newuser);

                return RedirectToAction("List", "Job");
            }

            return View();
        }
        private void HttpSiginAsyncreg1(User model)
        {
            var clamis = new List<Claim>();
            clamis.Add(new Claim(ClaimTypes.Name, model.PhoneNumber));
            clamis.Add(new Claim(ClaimTypes.NameIdentifier, model.LastName));

            var claimsIdentity = new ClaimsIdentity(clamis,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrinsipal = new ClaimsPrincipal(claimsIdentity);

            HttpContext.SignInAsync(claimsPrinsipal);
        }
		[HttpGet]
        public ViewResult Login1() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login1(Login1ViewModel model) 
        {
            var user = await repo.UserReturn1(model);
            if (user == null)
                return null;

            var verif = await repo.VerifyPassword(model.Password, user.PasswordHash, user.PasswordSalt);
            if (!verif)
                return null;

            HttpSiginAsync1(user);

            return RedirectToAction("List", "Job");
        }

        private void HttpSiginAsync1(User user)
        {
            var clamis = new List<Claim>();
            clamis.Add(new Claim(ClaimTypes.Name, user.FirstName));
            clamis.Add(new Claim(ClaimTypes.NameIdentifier, user.LastName));

            var claimsIdentity = new ClaimsIdentity(clamis,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrinsipal = new ClaimsPrincipal(claimsIdentity);



            HttpContext.SignInAsync(claimsPrinsipal);
        }
    }

}

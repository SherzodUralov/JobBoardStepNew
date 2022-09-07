using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using JobBoardStep.Core.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace JobBoardStepNew.path.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRepository repository;

        public JobController(IJobRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Create()        
        {
            var modelsession = HttpContext.Session.GetString("language");
            ViewBag.jobcategory = new SelectList(repository.JCTList(modelsession),"Id", "JobCatName");
            ViewBag.jobtype = new SelectList(repository.JTTList(modelsession), "Id", "Name");
            ViewBag.exper = new SelectList(repository.ETList(modelsession), "Id", "Name");
            string data = User.Identity.Name;

            var user = repository.UserGet(data);

            ViewBag.user = user.UserId;

            return View();
        }
        [HttpPost]
        public IActionResult Create(JobCreateViewModel jobCreateView)
        {
            var data = repository.CreateNew(jobCreateView);
            repository.Create(data);
            return RedirectToAction(nameof(List));
        }
        public IActionResult List(int pg = 1, string searchString = "")
        {
            ViewData["employer"] = "Employer";

            var modelsession = HttpContext.Session.GetString("language");
            var data = repository.JobList(modelsession);
            ViewData["CurrentFilter"] = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(x => x.Salary.Contains(searchString)).ToList();
            }
            const int pageSize = 6;
            if (pg < 1)
                pg = 1;
            int recsCount = data.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var model = data.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(model);
        }


        [HttpGet]
        public ViewResult Edit(int id)
        {
            var modelsession = HttpContext.Session.GetString("language");
            var model = repository.GetById(id);
            var newModel = repository.EditJob(model);
            ViewBag.jobcategory = new SelectList(repository.JCTList(modelsession), "Id", "JobCatName");
            ViewBag.jobtype = new SelectList(repository.JTTList(modelsession), "Id", "Name");
            ViewBag.exper = new SelectList(repository.ETList(modelsession), "Id", "Name");
       //     ViewBag.user = new SelectList(repository.UserGet(), "UserId", "FirstName");
            return View(newModel);
        }
        [HttpPost]
        public IActionResult Edit(JobEditViewModel job)
        {
            Job exsitngjob = repository.GetById(job.UserId);

            var model = repository.exsEdit(exsitngjob, job);

            repository.Update(model);

            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction(nameof(List));
        }
        //Language
        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                       new CookieOptions { Expires = DateTimeOffset.Now.AddDays(1) });
            HttpContext.Session.SetString("language", culture);

            return LocalRedirect(returnUrl);
        }
        public ViewResult EmpManage()
        {
            // string user = User.Identity.Name;
            // var user = repository.UserGet(data);
            ViewBag.data = HttpContext.Session.GetInt32("id");
            var modelsession = HttpContext.Session.GetString("language");
            var data = repository.JobEmpManageList(modelsession, ViewBag.data);
            return View(data);
        }
        [HttpGet]
        public IActionResult data(int id)
        {
            //sessiya aplication create uchun.
            HttpContext.Session.SetInt32("id", id);
            var da = repository.getById(id);
            return View(da);
        }
        [HttpGet]
        public ViewResult Register() 
        {
            return View();
        }
        public async Task<IActionResult> Register(JobRegisterViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var newuser = repository.NewUser1(model);

                HttpSiginAsyncreg1(newuser);

                await repository.CreateAsync(newuser);

                return  RedirectToAction("Create", "Job");
            }
            return View();
        }
        private void HttpSiginAsyncreg1(User model)
        {
            var clamis = new List<Claim>();
            if (model.PhoneNumber != null)
            {
                clamis.Add(new Claim(ClaimTypes.Name, model.PhoneNumber));
            }
            else
            {
                clamis.Add(new Claim(ClaimTypes.Name, model.Email));
            }
            clamis.Add(new Claim(ClaimTypes.NameIdentifier, model.LastName));

            var claimsIdentity = new ClaimsIdentity(clamis,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrinsipal = new ClaimsPrincipal(claimsIdentity);

            HttpContext.SignInAsync(claimsPrinsipal);
        }

    }
}

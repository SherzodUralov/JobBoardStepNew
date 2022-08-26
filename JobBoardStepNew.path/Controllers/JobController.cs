using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using JobBoardStep.Core.ViewModel;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult List(int pg = 1)
        {
            var modelsession = HttpContext.Session.GetString("language");
            var data = repository.JobList(modelsession);
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
            return View();
        }
        public IActionResult Data(int id = 4)
        {
            var data = repository.GetById(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult data(int id)
        {
            var da = repository.getById(id);
            return View(da);
        }
    }
}

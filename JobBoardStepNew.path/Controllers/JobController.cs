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
            ViewBag.jobcategory = new SelectList(repository.JCTList(),"Id", "JobCatName");
            ViewBag.jobtype = new SelectList(repository.JTTList(), "Id", "Name");
            ViewBag.exper = new SelectList(repository.ETList(), "Id", "Name");
            ViewBag.user = new SelectList(repository.UserGet(), "UserId", "FirstName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(JobCreateViewModel jobCreateView)
        {
            var data = repository.CreateNew(jobCreateView);
            repository.Create(data);
            return RedirectToAction(nameof(List));
        }
        public IActionResult List()
        {
            var data = repository.JobList();
            return View(data);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var model = repository.GetById(id);
            var newModel = repository.EditJob(model);
            ViewBag.jobcategory = new SelectList(repository.JCTList(), "Id", "JobCatName");
            ViewBag.jobtype = new SelectList(repository.JTTList(), "Id", "Name");
            ViewBag.exper = new SelectList(repository.ETList(), "Id", "Name");
            ViewBag.user = new SelectList(repository.UserGet(), "UserId", "FirstName");
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
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }
    }
}

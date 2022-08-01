using JobBoardStep.Core.Repository;
using JobBoardStep.Core.ViewModel;
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
    }
}

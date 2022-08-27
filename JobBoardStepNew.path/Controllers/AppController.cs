using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using JobBoardStep.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobBoardStepNew.path.Controllers
{
    public class AppController : Controller
    {
        private readonly IApplicationRepository repository;
        private readonly IJobRepository repositoryjob;

        public AppController(IApplicationRepository repository,IJobRepository repositoryjob)
        {
            this.repository = repository;
            this.repositoryjob = repositoryjob;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            string data = User.Identity.Name;
            var user = repositoryjob.UserGet(data);
<<<<<<< HEAD
          ViewBag.user = user.UserId;
          ViewBag.job = HttpContext.Session.GetInt32("id");
=======
            ViewBag.user = user.UserId;
            ViewBag.job = HttpContext.Session.GetInt32("id");
>>>>>>> 213d4c381b663af4b3afaa2a35cc0883f0808251
            return View();
        }
        [HttpPost]
        public IActionResult Create(AppCreateVMmin app)
        {
            repository.Add(app);
          return  RedirectToAction("List","Job");
        }

    }
}

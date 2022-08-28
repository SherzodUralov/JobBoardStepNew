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
        public IActionResult List(int id)
        {
            var data = repository.GetAll(id);
            return View(data);
        }
        public IActionResult Create()
        {
            string data = User.Identity.Name;
            var user = repositoryjob.UserGet(data);
          ViewBag.user = user.UserId;
          ViewBag.job = HttpContext.Session.GetInt32("id");
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

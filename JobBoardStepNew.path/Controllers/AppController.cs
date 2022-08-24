using JobBoardStep.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardStepNew.path.Controllers
{
    public class AppController : Controller
    {
        private readonly IApplicationRepository repository;

        public AppController(IApplicationRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}

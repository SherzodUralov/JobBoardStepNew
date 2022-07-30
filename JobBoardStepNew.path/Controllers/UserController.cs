using JobBoardStep.Core.Repository;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            return View();
        }
    }
}

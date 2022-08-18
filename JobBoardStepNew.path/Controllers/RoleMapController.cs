using JobBoardStep.Core.Repository;
using JobBoardStep.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobBoardStepNew.path.Controllers
{
    
    public class RoleMapController : Controller
    {
        private readonly IRoleMapRepo repo;

        public RoleMapController(IRoleMapRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var model = repo.GetAll();
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            ViewData["role"] = new SelectList(repo.listrole(), "Id", "RoleName");
            ViewData["user"] = new SelectList(repo.listuser(), "UserId", "Email");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleMapViewModel model)
        {
            await repo.CreateAsync(model);

            return RedirectToAction("Index", "RoleMap");
        }
    }
}

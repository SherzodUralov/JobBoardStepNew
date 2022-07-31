using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using JobBoardStep.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [HttpGet]
        public ViewResult Create() 
        {
            ViewBag.region = new SelectList(repo.RegionList(), "Id", "Name");
            ViewBag.infor = new SelectList(repo.InfroList(), "Id", "Name");
            ViewBag.usertype = new SelectList(repo.UserTypeList(), "UserTypeId", "UserTypeName");
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserCreateViewModel userCreate)
        {
            var newuser = repo.NewUser(userCreate);
            repo.Create(newuser);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ViewResult Edit(int id) 
        {
            var model = repo.GetById(id);
            ViewBag.region = new SelectList(repo.RegionList(), "Id", "Name");
            ViewBag.infor = new SelectList(repo.InfroList(), "Id", "Name");
            ViewBag.usertype = new SelectList(repo.UserTypeList(), "UserTypeId", "UserTypeName");
            return View(model);
        }
    }
}

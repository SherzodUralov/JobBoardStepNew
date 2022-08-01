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
        public IActionResult Create(UserCreateViewModel userCreate)
        {
            if (ModelState.IsValid)
            {
                var newuser = repo.NewUser(userCreate);

                repo.Create(newuser);

                return RedirectToAction("List");
            }
            ViewBag.region = new SelectList(repo.RegionList(), "Id", "Name");

            ViewBag.infor = new SelectList(repo.InfroList(), "Id", "Name");

            ViewBag.usertype = new SelectList(repo.UserTypeList(), "UserTypeId", "UserTypeName");
            return View(); 
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            var model = repo.GetById(id);

            var newuser = repo.UpdateUser(model);

            ViewBag.region = new SelectList(repo.RegionList(), "Id", "Name");

            ViewBag.infor = new SelectList(repo.InfroList(), "Id", "Name");

            ViewBag.usertype = new SelectList(repo.UserTypeList(), "UserTypeId", "UserTypeName");

            return View(newuser);
        }
<<<<<<< HEAD
        //[HttpPost]
        //public IActionResult Edit()
        //{
        //    var model = repo.GetById(0);    
        //}

=======
        [HttpPost]
        public IActionResult Edit(UserEditViewModel user)
        {
            User exsitnguser = repo.GetById(user.UserId);

            var model = repo.ExsingUser(exsitnguser, user);

            repo.Update(model);

            return RedirectToAction("List");
        }
        public IActionResult Delete(int id) 
        {
            repo.Delete(id);

            return RedirectToAction("List");
        }
>>>>>>> 37d60d738f3f1037f791f632167784ff92b618f8
    }

}

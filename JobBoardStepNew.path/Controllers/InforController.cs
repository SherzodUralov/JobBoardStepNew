using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobBoardStepNew.path.Controllers
{
    public class InforController : Controller
    {
        private readonly IInformationRepo repo;

        public InforController(IInformationRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            Information information = new Information();
            information.InformationTranslates.Add(new InformationTranslate() {Id=1 });
            var x = repo.GetLan();
            ViewBag.lang = new SelectList(x, "Id", "LanguageName");
            return View(information);
        }
        [HttpPost]
        public IActionResult Create(Information information) 
        {
            repo.Create(information);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ViewResult Edit(int id) 
        {
            var information = repo.GetById(id);
            return View(information);
        }
        //[HttpPost]
        //public IActionResult Edit() 
        //{
        //    return View();
        //}
        public ViewResult List() 
        {
            var model =  repo.GetAll();
            return View(model);
        }
    }
}

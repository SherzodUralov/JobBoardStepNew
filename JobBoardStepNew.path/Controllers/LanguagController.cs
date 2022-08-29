using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using JobBoardStep.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardStepNew.path.Controllers
{
    public class LanguagController : Controller
    {
        private readonly ILanguagRepo repo;

        public LanguagController(ILanguagRepo repo)
        {
            this.repo = repo;
        }
        public ViewResult Index(string sortOrder, string searchString)
        
        { 
            ViewData["FirstNameSortParm"] = sortOrder == "first_name" ? "first_name_desc" : "first_name";
           
            ViewData["CurrentFilter"] = searchString;
           
            var model = repo.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.LanguageName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "first_name_desc":
                    model = repo.GetAll().OrderByDescending(x => x.LanguageName);
                    break;
                case "first_name":
                    model = repo.GetAll().OrderBy(x => x.LanguageName);
                    break;
                default:
                    break;
            }

            return View(model);
        }
        [HttpGet]
        public ViewResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Language language)
        {
            if (ModelState.IsValid)
            {
                await repo.Create(language);

                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public async Task<ViewResult> Edit(int id) 
        {
            var model = await repo.GetById(id);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Language language) 
        {
            if (ModelState.IsValid)
            {
                await repo.Update(language);
            }
            return RedirectToAction("Index");
        }

    }
}

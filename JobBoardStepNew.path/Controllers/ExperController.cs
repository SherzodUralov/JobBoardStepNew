using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobBoardStepNew.path.Controllers
{
    public class ExperController : Controller
    {
        private readonly IExperienceRepo experience;

        public ExperController(IExperienceRepo experience)
        {
            this.experience = experience;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult List()
        {
            var model = experience.experLists();

            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            Experience experienc = new Experience();

            experienc.ExperienceTranslates.Add(new ExperienceTranslate() { Id = 1 });

            ViewBag.expert = new SelectList(experience.translates(), "Id", "Name");

            ViewBag.lang = new SelectList(experience.languages(), "Id", "LanguageName");

            return View(experienc);
        }
        [HttpPost]
        public IActionResult Create(Experience experien)
        {
            experience.Create(experien);

            return RedirectToAction("List");
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            var model = experience.GetById(id);

            ViewBag.expert = new SelectList(experience.translates(), "Id", "Name");

            ViewBag.lang = new SelectList(experience.languages(), "Id", "LanguageName");

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Experience exper)
        {
            experience.List(exper);
            experience.Update(exper);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var expe = experience.GetById(id);
            if (expe != null)
            {
                experience.Delete(expe);
            }
            return RedirectToAction("List");
        }
    }
}

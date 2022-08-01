
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

            var x = repo.GetLan();

            ViewBag.lang = new SelectList(x, "Id", "LanguageName");

            return View(information);
        }
        [HttpPost]
        public IActionResult Edit(Information information)
        {
            repo.List(information);

            repo.Update(information);

            return RedirectToAction("List");
        }
        public IActionResult Delete(int id) 
        {
            repo.Delete(id);

            return RedirectToAction("List");
        }
        public IActionResult List(int pg = 1)
        {
            var data = repo.GetAll();

            const int pageSize = 5;

            if (pg < 1)
                pg = 1;

            int recsCount = data.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data1 = data.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data1);
        }
    }
}

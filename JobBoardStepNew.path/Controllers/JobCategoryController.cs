using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobBoardStepNew.path.Controllers
{
    public class JobCategoryController : Controller
    {
        private readonly IJobCategoryRepository repo;

        public JobCategoryController(IJobCategoryRepository repo)
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
            JobCategory category = new JobCategory();
            category.JobCategoryTranslates.Add(new JobCategoryTranslate() { Id = 1 });
            var x = repo.GetLang();
            ViewBag.lang = new SelectList(x, "Id", "LanguageName");
            return View(category);
        }
        [HttpPost]
        public IActionResult Create(JobCategory category)
        {
            repo.Create(category);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            var category = repo.GetById(id);
            var x = repo.GetLang();
            ViewBag.lang = new SelectList(x, "Id", "LanguageName");
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(JobCategory category)
        {
            repo.List(category);
            repo.Update(category);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var category = repo.GetById(id);
            if (category != null)
            {
                repo.Delete(category);
            }
            return RedirectToAction("List");
        }

        public IActionResult List(int pg = 1)
        {
            var data = repo.GetCategory();
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

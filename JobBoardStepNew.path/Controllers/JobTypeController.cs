using JobBoardStep.Core.Models;
using JobBoardStep.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobBoardStepNew.path.Controllers
{
    public class JobTypeController : Controller
    {
        private readonly IJobTypeRepository repository;

        public JobTypeController(IJobTypeRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            JobType type = new JobType();
            type.JobTypeTranslates.Add(new JobTypeTranslate() { Id = 1 });
            var x = repository.GetLanguages();
            ViewBag.lang = new SelectList(x, "Id", "LanguageName");
            return View(type);
        }
        [HttpPost]
        public IActionResult Create(JobType jobType)
        {
            repository.Create(jobType);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult Edit(int  id)
        {
            var data = repository.GetById(id);
            var x = repository.GetLanguages();
            ViewBag.lang = new SelectList(x ,"Id", "LanguageName");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(JobType jobType)
        {
            repository.List(jobType);
            repository.Update(jobType);
            return RedirectToAction(nameof(List));
        }
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction(nameof(List));
        }
        public IActionResult List(int pg = 1)
        {   var data = repository.GetAll();
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

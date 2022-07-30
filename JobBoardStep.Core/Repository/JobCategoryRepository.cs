using JobBoardStep.Core.Context;
using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Repository
{
    public class JobCategoryRepository : IJobCategoryRepository
    {
        private readonly AppDbContext context;

        public JobCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(JobCategory category)
        {
            context.JobCategories.Add(category);    
           context.SaveChanges();
        }

        public void Delete(JobCategory category)
        {
            context.JobCategories.Remove(category);
            context.SaveChanges();
        }

        public JobCategory GetById(int id)
        {
          var data = context.JobCategories
                .Include(x => x.JobCategoryTranslates)
                .Where(a => a.Id.Equals(id)).FirstOrDefault();
            return data;
        }

        public IList<CategoryListViewModel> GetCategory()
        {
            var model = (from t in context.JobCategoryTranslates
                         join J in context.JobCategories
                         on t.JobCatId equals J.Id
                         join l in context.Languages
                         on t.LanguageId equals l.Id
                         select new CategoryListViewModel
                         {
                             Id = J.Id,
                             CategoryName = t.JobCatName,
                             LangName = l.LanguageName,
                             CreateDate = J.CreateDate,
                             UpdateDate = J.UpdateDate,
                             
                         }

               ).ToList();
            return model;
        }

        public IList<Language> GetLang()
        {
            return context.Languages.ToList();
        }

        public void List(JobCategory category)
        {
            List<JobCategoryTranslate> list = context.JobCategoryTranslates.Where(a => a.JobCatId == category.Id).ToList();
            context.JobCategoryTranslates.RemoveRange(list);
            context.SaveChanges();
        }

        public void Update(JobCategory category)
        {
           context.JobCategories.Update(category);
            context.SaveChanges();
        }
    }
}

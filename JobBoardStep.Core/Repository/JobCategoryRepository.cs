using JobBoardStep.Core.Context;
using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public JobCategory GetById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update(JobCategory category)
        {
            throw new NotImplementedException();
        }
    }
}

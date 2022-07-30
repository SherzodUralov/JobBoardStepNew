using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Repository
{
    public interface IJobCategoryRepository
    {
        JobCategory GetById(int id);
        void Update(JobCategory category);
        void Delete(int id);
        void Create(JobCategory category);
        IList<Language> GetLang();
        IList<CategoryListViewModel> GetCategory();
    }
}

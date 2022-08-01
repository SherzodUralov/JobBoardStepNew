using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Repository
{
    public interface IJobRepository
    {
        IList<JobListViewModel> JobList();
        void Create(Job job);
        void Update(Job job);
        void Delete(int id);
        Job CreateNew(JobCreateViewModel jobcreate);
        List<JobCategoryTranslate> JCTList();
        List<JobTypeTranslate> JTTList();
        List<ExperienceTranslate> ETList();
        Job GetById(int id);
        List<User> UserGet();
        JobEditViewModel EditJob(Job jobedit);
        Job exsEdit(Job job,JobEditViewModel jobEditView);
     
    }
}

using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Repository
{
    public interface IJobTypeRepository
    {
        JobType GetById(int id);
        void Create(JobType jobType);
        void Update(JobType jobType);
        void Delete(int id);
        IList<Language> GetLanguages();
        IList<JobTypeViewModel> GetAll();
        void List(JobType jobType);
       
    }
}

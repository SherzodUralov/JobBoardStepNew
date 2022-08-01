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
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext context;

        public JobRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(Job job)
        {
           context.Jobs.Add(job);
            context.SaveChanges();
        }

        public Job CreateNew(JobCreateViewModel jobcreate)
        {
            
            JobCategory jobCat = context.JobCategories.FirstOrDefault(x => x.Id.Equals(jobcreate.JobCateId));
            JobType jobType = context.JobTypes.FirstOrDefault(x => x.Id.Equals(jobcreate.JobTypeId));
            Experience exper = context.Experiences.FirstOrDefault(x => x.Id.Equals(jobcreate.ExperienceId));
            User user = context.Users.FirstOrDefault(x => x.UserId.Equals(jobcreate.UserId));
            Job newjob = new Job()
            {
                JobId = jobcreate.JobId,
                Salary = jobcreate.Salary,
                Description = jobcreate.Description,
                CareateDate = jobcreate.CareateDate,
                UpdateDate = jobcreate.UpdateDate,
                JobCateId = jobcreate.JobCateId,
                JobTypeId = jobcreate.JobTypeId,
                ExperienceId = jobcreate.ExperienceId,
                UserId = jobcreate.UserId
            };
            return newjob;
        }

        public List<ExperienceTranslate> ETList()
        {
           return context.ExperienceTranslates.ToList();
        }

        public Job GetById(int id)
        {
            return context.Jobs.Find(id);
        }

        public List<JobCategoryTranslate> JCTList()
        {
            return context.JobCategoryTranslates.ToList();
        }

        public IList<JobListViewModel> JobList()
        {

            var model = (from J in context.Jobs
                         join JC in context.JobCategories
                         on J.JobCateId equals JC.Id
                         join JCT in context.JobCategoryTranslates
                         on JC.Id equals JCT.JobCatId
                         join JT in context.JobTypes
                         on J.JobTypeId equals JT.Id
                         join JTT in context.JobTypeTranslates
                         on JT.Id equals JTT.JobTypeId
                         join E in context.Experiences
                         on J.ExperienceId equals E.Id
                         join ET in context.ExperienceTranslates
                         on E.Id equals ET.ExperienceId
                         join U in context.Users
                         on J.UserId equals U.UserId
                         select new JobListViewModel
                         {
                             JobId = J.JobId,
                             Salary = J.Salary,
                             Description = J.Description,
                             CareateDate = J.CareateDate,
                             UpdateDate = J.UpdateDate,
                             JobCatName = JCT.JobCatName,
                             JobTypeName = JTT.Name,
                             ExperName = ET.Name,
                             UserName = U.FirstName
                             
                         }
                         ).ToList();
            return model;

        }

        public List<JobTypeTranslate> JTTList()
        {
            return context.JobTypeTranslates.ToList();
        }

        public List<User> UserGet()
        {
            return context.Users.ToList();
        }
    }
}

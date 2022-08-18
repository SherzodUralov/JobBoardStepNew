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
    public class JobTypeRepository : IJobTypeRepository
    {
        private readonly AppDbContext context;

        public JobTypeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(JobType jobType)
        {
            context.JobTypes.Add(jobType);
            context.SaveChanges();  
        }

        public void Delete(int id)
        {
            var data = context.JobTypes.Find(id);
            if (data != null)
            {
                context.JobTypes.Remove(data);
                context.SaveChanges();
            }
        }

        public IList<JobTypeViewModel> GetAll()
        {
            var model = (from JTT in context.JobTypeTranslates
                         join JT in context.JobTypes
                         on JTT.JobTypeId equals JT.Id
                         join L in context.Languages
                         on JTT.LanguageId equals L.Id
                         select new JobTypeViewModel
                         {
                             Id = JT.Id,
                             JobTypeName = JTT.Name,
                             LangName=L.LanguageName,
                             CreateDate = JT.CareateDate,
                             UpdateDate = JT.UpdateDate,
                             JobTypeStatus = JT.JobTypeStatus
                         }

                ).ToList();
            return model;
        }

        public JobType GetById(int id)
        {
            var data = context.JobTypes
                .Include(x => x.JobTypeTranslates)
                .Where(x => x.Id.Equals(id)).FirstOrDefault();
            return data;
        }

        public IList<Language> GetLanguages()
        {
            return context.Languages.ToList();
        }

        public void List(JobType jobType)
        {
            List<JobTypeTranslate> lest = context.JobTypeTranslates.Where(x => x.JobTypeId == jobType.Id).ToList();
            context.JobTypeTranslates.RemoveRange(lest);
            context.SaveChanges();
        }

        public void Update(JobType jobType)
        {
           context.JobTypes.Update(jobType);
            context.SaveChanges();
        }
    }
}

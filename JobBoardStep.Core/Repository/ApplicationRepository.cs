using JobBoardStep.Core.Context;
using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Repository
{
    public class ApplicationRepository:IApplicationRepository
    {
        private readonly AppDbContext contex;

        public ApplicationRepository(AppDbContext contex)
        {
            this.contex = contex;
        }

        public void Add(AppCreateVMmin appCreate)
        {
            Application app = new Application()
            {
                ApplicationId = appCreate.AplicationId,
                CreateDate = appCreate.CreateDate,
                ApplicationStatus = appCreate.Status,
                UpdateDate = appCreate.UpdateDate,
                JobId = appCreate.JobId,
                UserId = appCreate.UserId,
                FilePath = appCreate.FilePath,
            };
            contex.Add(app);
            contex.SaveChanges();

        }

        public IList<ApplicationListViewModel> GetAll(int id)
        {
            var model = (from ap in contex.Applications
                         join j in contex.Jobs
                         on ap.JobId equals j.JobId
                         join u in contex.Users
                         on ap.UserId equals u.UserId
                         where u.UserId == ap.UserId && j.JobId == id
                         select new ApplicationListViewModel
                         {
                             ApplicationId = ap.ApplicationId,
                             CreateDate = ap.CreateDate,
                             FirstName = u.FirstName,
                             FilePath = ap.FilePath,
                             ApplicationStatus = ap.ApplicationStatus,
                             JobCatName = j.JobCategoryTranslate.JobCatName,
                             Phone = u.PhoneNumber
                         }).ToList();
            return model;
        }

        public IList<User> GetUsers()
        {
            var model = (from u in contex.Users
                         select new User
                         {
                             UserId = u.UserId,
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             PhoneNumber = u.PhoneNumber
                         }).ToList();
            return model;
        }
    }
}

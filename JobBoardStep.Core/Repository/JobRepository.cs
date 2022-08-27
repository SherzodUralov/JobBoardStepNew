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
            
            JobCategoryTranslate jobCat = context.JobCategoryTranslates.FirstOrDefault(x => x.Id.Equals(jobcreate.JobCateTrId));
            JobTypeTranslate jobType = context.JobTypeTranslates.FirstOrDefault(x => x.Id.Equals(jobcreate.JobTypeTrId));
            ExperienceTranslate exper = context.ExperienceTranslates.FirstOrDefault(x => x.Id.Equals(jobcreate.ExperienceTrId));
            //User data = context.Users.FirstOrDefault(a => a.UserId.Equals(jobcreate.UserId));

            Job newjob = new Job()
            {
                JobId = jobcreate.JobId,
                Salary = jobcreate.Salary,
                Description = jobcreate.Description,
                CareateDate = jobcreate.CareateDate,
                UpdateDate = jobcreate.UpdateDate,
                JobCatTId = jobcreate.JobCateTrId,
                JobCateId = jobCat.JobCatId,
                JobTypeTId = jobcreate.JobTypeTrId,
                JobTypeId = jobType.JobTypeId,
                ExperTId = jobcreate.ExperienceTrId,
                ExperienceId = exper.ExperienceId,
                UserId =jobcreate.UserId
            };
            return newjob;
        }

        public void Delete(int id)
        {
            var data = context.Jobs.Find(id);
            if (data != null)
            {
                context.Jobs.Remove(data);
                context.SaveChanges();
            }
         }

        public JobEditViewModel EditJob(Job jobedit)
        {
            JobEditViewModel jobEditView = new JobEditViewModel()
            {
                JobId = jobedit.JobId,
                Salary = jobedit.Salary,
                CareateDate = jobedit.CareateDate,
                UpdateDate = jobedit.UpdateDate,
                Description = jobedit.Description,
                ExperienceTrId = jobedit.ExperTId,
                JobCateTrId = jobedit.JobCatTId,
                JobTypeTrId = jobedit.JobTypeTId,
                UserId = jobedit.UserId
            };
            return jobEditView;
        }

        public List<ExperienceTranslate> ETList(string lang)
        {
            if (lang == null)
            {
                lang = "en";
            }
           return context.ExperienceTranslates.Where(x => x.Language.LanguageName == lang).ToList();
        }

        public Job exsEdit(Job job, JobEditViewModel jobEditView)
        {
            ExperienceTranslate exper = context.ExperienceTranslates.FirstOrDefault(x => x.Id.Equals(jobEditView.ExperienceTrId));
            JobTypeTranslate jobType = context.JobTypeTranslates.FirstOrDefault(x => x.Id.Equals(jobEditView.JobTypeTrId));
            JobCategoryTranslate jobCat = context.JobCategoryTranslates.FirstOrDefault(x => x.Id.Equals(jobEditView.JobCateTrId));
            job.Salary = jobEditView.Salary;
            job.CareateDate = jobEditView.CareateDate;
            job.UpdateDate = jobEditView.UpdateDate;
            job.Description = jobEditView.Description;
            job.ExperTId = jobEditView.ExperienceTrId;
            job.ExperienceId = exper.ExperienceId;
            job.JobCatTId = jobEditView.JobCateTrId;
            job.JobCateId = jobCat.JobCatId;
            job.JobTypeTId = jobEditView.JobTypeTrId;
            job.JobTypeId = jobType.JobTypeId;
            job.UserId = jobEditView.UserId;
            return job;

        }

        public Job GetById(int id)
        {
            return context.Jobs.Find(id);
        }

        public IList<JobListViewModel> getById(int id)
        {
            var d1 = GetById(id);
            
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
                         where J.JobId == id
                         where d1.ExperTId == ET.Id
                         where  d1.JobCatTId == JCT.Id
                         where d1.JobTypeTId == JTT.Id
                         where d1.UserId == U.UserId
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

                         }).ToList();
            return model;
        }

        public List<JobCategoryTranslate> JCTList(string lang)
        {
            if (lang == null)
            {
                lang = "en";
            }
            return context.JobCategoryTranslates.Where(x => x.Language.LanguageName == lang).ToList();
        }

        public IList<JobListViewModel> JobList(string lang)
        {
            if (lang == null)
            {
                lang = "en";
            }
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
                         where JCT.Language.LanguageName == lang
                         where JTT.Language.LanguageName == lang
                         where ET.Language.LanguageName == lang
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

        public List<JobTypeTranslate> JTTList(string lang)
        {
            if (lang == null)
            {
                lang = "en";
            }
            return context.JobTypeTranslates.Where(x => x.Language.LanguageName == lang).ToList();
        }

        public string Login()
        {
            throw new NotImplementedException();
        }

        public void Update(Job job)
        {
            context.Jobs.Update(job);
            context.SaveChanges();
        }

        public User UserGet(string a)
        {
            User user;

            if (a.Contains('@'))
            {
                user = context.Users.FirstOrDefault(x => x.Email.Equals(a));
            }
            else
            {
                user = context.Users.FirstOrDefault(x => x.PhoneNumber.Equals(a));    
            }

            return user;
        }
        public User NewUser1(JobRegisterViewModel model)
        {
            string Email = "";

            string PhoneNumber = "";

            bool next = model.PhoneOrEmail.Contains('@');

            if (next)
            {
                Email = model.PhoneOrEmail;
            }
            else
            {
                PhoneNumber = model.PhoneOrEmail;
            }

            byte[] passworhash, passworsalt;

            CreatePassworHash(model.Password, out passworhash, out passworsalt);

            User newuser = new User
            {
                FirstName = model.FirstName,

                LastName = model.LastName,

                Email = Email,

                PhoneNumber = PhoneNumber,

                PasswordHash = passworhash,

                PasswordSalt = passworsalt,

                UserTypeId = 1
            };

            return newuser;
        }
        public void CreatePassworHash(string Password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;

                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }

        public async Task CreateAsync(User user)
        {
                  await context.Users.AddAsync(user);

                  await context.SaveChangesAsync();
        }
    }
}

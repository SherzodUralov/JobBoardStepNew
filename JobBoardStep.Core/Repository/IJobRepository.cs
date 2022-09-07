﻿using JobBoardStep.Core.Models;
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
        IList<JobListViewModel> JobList(string lang);
        IList<JobListViewModel> JobEmpManageList(string lang,int id);
        IList<JobListViewModel> getById(int id, string lang);
        void Create(Job job);
        void Update(Job job);
        void Delete(int id);
        Job CreateNew(JobCreateViewModel jobcreate);
        List<JobCategoryTranslate> JCTList(string lang);
        List<JobTypeTranslate> JTTList(string lang);
        List<ExperienceTranslate> ETList(string lang);
        Job GetById(int id);
        User UserGet(string a);
        JobEditViewModel EditJob(Job jobedit);
        Job exsEdit(Job job,JobEditViewModel jobEditView);

        User NewUser1(JobRegisterViewModel model);

        Task CreateAsync(User user);

    }
}

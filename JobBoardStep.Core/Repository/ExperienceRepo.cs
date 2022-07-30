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
    public class ExperienceRepo : IExperienceRepo
    {
        private readonly AppDbContext context;

        public ExperienceRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(Experience experience)
        {
            context.Experiences.Add(experience);
            context.SaveChanges();
        }

        public void Delete(Experience experience)
        {
            context.Experiences.Remove(experience);
            context.SaveChanges();
        }

        public IList<ExperListViewModel> experLists()
        {
            var model = (from e in context.Experiences
                         join et in context.ExperienceTranslates
                         on e.Id equals et.ExperienceId
                         join l in context.Languages
                         on et.LanguageId equals l.Id
                         select new ExperListViewModel
                         {
                             Id = e.Id,
                             ExperName = et.Name,
                             Langname = l.LanguageName,
                             CareateDate = e.CareateDate,
                             UpdateDate = e.UpdateDate,
                             ExperienceStatus = e.ExperienceStatus,
                         }
                        ).ToList();
            return model;
        }

        public Experience GetById(int id)
        {
            return context.Experiences
                .Include(w => w.ExperienceTranslates)
                .Where(t => t.Id.Equals(id)).FirstOrDefault();
        }

        public List<Language> languages()
        {
            return context.Languages.ToList();
        }

        public void List(Experience experience)
        {
            List<ExperienceTranslate> list = context.ExperienceTranslates.Where(a => a.ExperienceId == experience.Id).ToList();
            context.ExperienceTranslates.RemoveRange(list);
            context.SaveChanges();
        }

        public List<ExperienceTranslate> translates()
        {
            return context.ExperienceTranslates.ToList();
        }

        public void Update(Experience experience)
        {
            context.Experiences.Update(experience);
            context.SaveChanges();
        }
    }
}

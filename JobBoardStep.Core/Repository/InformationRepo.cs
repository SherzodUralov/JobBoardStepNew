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
    public class InformationRepo : IInformationRepo
    {
        private readonly AppDbContext context;

        public InformationRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(Information information)
        {
            context.Information.Add(information);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var infor = context.Information.Find(id);
            if (infor != null)
            {
                context.Information.Remove(infor);

                context.SaveChanges();
            }
        }

        public IList<InforListViewModel> GetAll()
        {
            var model = (from t in context.InformationTranslates

                         join I in context.Information

                         on t.InformationId equals I.Id

                         join l in context.Languages

                         on t.LanguageId equals l.Id

                         select new InforListViewModel
                         {
                             Id = I.Id,

                             InforName = t.Name,

                             LangName = l.LanguageName,

                             CreateDate = I.CreateDate,

                             UpdateDate = I.UpdateDate,

                             InformationStatus = I.InformationStatus
                         }

                ).ToList();

            return model;
        }

        public Information GetById(int id)
        {
            return context.Information

                .Include(e => e.InformationTranslates)

                .FirstOrDefault(a => a.Id.Equals(id));
        }

        public IList<Language> GetLan()
        {
            return context.Languages.ToList();
        }

        //public List<InformationTranslate> list(Information information)
        //{
        //    var list = context.InformationTranslates.Where(a => a.InformationId == information.Id).ToList();
        //    context.InformationTranslates.RemoveRange(list);
        //    context.SaveChanges();
        //    return list;
        //}

        public void List(Information information)
        {
            List<InformationTranslate> list = context.InformationTranslates.Where(a => a.InformationId == information.Id).ToList();

            context.InformationTranslates.RemoveRange(list);

            context.SaveChanges();
        }

        public void Update(Information information)
        {
            context.Information.Update(information);

            context.SaveChanges();
        }
    }
}

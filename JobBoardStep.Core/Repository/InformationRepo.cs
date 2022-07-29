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

        public void Delete(Information information)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IList<Language> GetLan()
        {
            return context.Languages.ToList();
        }

        public void Update(Information information)
        {
            throw new NotImplementedException();
        }
    }
}

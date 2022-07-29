using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Repository
{
    public interface IInformationRepo
    {
        Information GetById(int id);
        void Create(Information information);
        void Update(Information information);
        void Delete(Information information);
        IList<InforListViewModel> GetAll();
        IList<Language> GetLan();

    }
}

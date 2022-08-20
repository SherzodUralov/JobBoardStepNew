using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Repository
{
    public interface ILanguagRepo
    {
        Task<Language> GetById(int id);

        Task Create(Language language);

        Task Update(Language language);

        Task Delete(int id);

        IEnumerable<Language> GetAll();

    }
}

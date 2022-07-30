using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Repository
{
    public interface IExperienceRepo
    {
        Experience GetById(int id);
        void Create(Experience experience);
        void Update(Experience experience); 
        void Delete(Experience experience);
        IList<ExperListViewModel> experLists();
        List<ExperienceTranslate> translates();
        List<Language> languages();
        void List(Experience experience);
    }
}

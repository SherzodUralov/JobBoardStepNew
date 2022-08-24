using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Repository
{
    public interface IApplicationRepository
    {
        IList<ApplicationListViewModel> GetAll();
        void Add(AppCreateVMmin appCreate);
    }
}

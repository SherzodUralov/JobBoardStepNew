using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Repository
{
    public interface IRoleMapRepo
    {
        Task CreateAsync(RoleMapViewModel maping);
        Task UpdateAsync(RoleMap roleMap);
        Task DeleteAsync(RoleMap roleMap);
        List<MapIndexViewModel> GetAll();
        List<Role> listrole();
        List<User> listuser();
    }
}

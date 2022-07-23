using JobBoardStep.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Repository
{
    public interface IUserRepositroy
    {
        User GetById(int id);
        IEnumerable<User> GetAll();
        User Create(User user);
        User Update(User user);
        User Delete(int id);

    }
}

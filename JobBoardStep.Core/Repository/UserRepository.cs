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
    public class UserRepository : IUserRepositroy
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public User Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }

        public IList<UserListViewModel> UserList()
        {
            var model = (from u in context.Users
                         join it in context.Information
                         on u.InformationId equals it.Id
                         join itt in context.InformationTranslates
                         on it.Id equals itt.InformationId
                         join ut in context.UserTypes
                         on u.UserTypeId equals ut.UserTypeId
                         join r in context.Regions
                         on u.RegionId equals r.Id

                         select new UserListViewModel
                         {
                             UserId = u.UserId,
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             MiddleName = u.MiddleName,
                             Email = u.Email,
                             PassportNumber = u.PassportNumber,
                             BirthDate = u.BirthDate,
                             CreateDate = u.CreateDate,
                             InformatTName = itt.Name,
                             UserType = ut.UserTypeName,
                             Region = r.Name
                         }
                         ).ToList();
            return model;
        }
    }
}

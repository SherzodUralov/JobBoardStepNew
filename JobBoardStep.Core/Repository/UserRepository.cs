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
        public void Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public List<InformationTranslate> InfroList()
        {
            return context.InformationTranslates.ToList();
        }

        public User NewUser(UserCreateViewModel newuser)
        {
            InformationTranslate information = context.InformationTranslates.FirstOrDefault(item => item.Id.Equals(newuser.InforTranId));

            User newuser1 = new User
            {
                UserId = newuser.UserId,
                FirstName = newuser.FirstName,
                LastName = newuser.LastName,
                MiddleName = newuser.MiddleName,
                Email = newuser.Email,
                PassportNumber = newuser.PassportNumber,
                BirthDate = newuser.BirthDate,
                CreateDate = newuser.CreateDate,
                RegionId = newuser.RegionId,
                UserTypeId = newuser.UserTypeId,
                InformatTrId = newuser.InforTranId,
                InformationId = information.InformationId
            };
            return newuser1;
        }

        public List<Region> RegionList()
        {
            return context.Regions.ToList();
        }

        public void Update(User user)
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

        public List<UserType> UserTypeList()
        {
            return context.UserTypes.ToList();
        }
    }
}

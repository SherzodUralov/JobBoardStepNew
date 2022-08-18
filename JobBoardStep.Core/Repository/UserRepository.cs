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
            var user = context.Users.Find(id);

            if (user != null)
            {
                context.Users.Remove(user);

                context.SaveChanges();
            }
        }

        public User ExsingUser(User exstinguser, UserEditViewModel user)
        {
            InformationTranslate infor = context.InformationTranslates.FirstOrDefault(item => item.Id.Equals(user.InforTranId));

            exstinguser.FirstName = user.FirstName;

            exstinguser.LastName = user.LastName;

            exstinguser.MiddleName = user.MiddleName;

            exstinguser.Email = user.Email;

            exstinguser.PassportNumber = user.PassportNumber;

            exstinguser.BirthDate = user.BirthDate;

            exstinguser.CreateDate = user.CreateDate;

            exstinguser.RegionId = user.RegionId;

            exstinguser.UserTypeId = user.UserTypeId;

            exstinguser.InformatTrId = user.InforTranId;

            exstinguser.InformationId = infor.InformationId;

            return exstinguser;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public List<InformationTranslate> InfroList(string lang)
        {
            if (lang == null)
            {
                lang = "en";
            }

            return context.InformationTranslates.Where(x => x.Language.LanguageName.Equals(lang)).ToList();
        }

        public User NewUser(string UniqueFileName, UserCreateViewModel newuser)
        {
            InformationTranslate information = context.InformationTranslates.FirstOrDefault(item => item.Id.Equals(newuser.InforTranId));

            byte[] passwordHash, passwordSalt;

            CreatePassworHash(newuser.Password, out passwordHash, out passwordSalt);

            User newuser1 = new User
            {
                UserId = newuser.UserId,

                FirstName = newuser.FirstName,

                LastName = newuser.LastName,

                MiddleName = newuser.MiddleName,

                Email = newuser.Email,

                PasswordHash = passwordHash,

                PasswordSalt = passwordSalt,

                PassportNumber = newuser.PassportNumber,

                BirthDate = newuser.BirthDate,

                CreateDate = newuser.CreateDate,
                
                 PhotoFilePath = UniqueFileName,

                RegionId = newuser.RegionId,

                UserTypeId = newuser.UserTypeId,

                InformatTrId = newuser.InforTranId,

                InformationId = information.InformationId
            };
            return newuser1;
        }

        public void CreatePassworHash(string Password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;

                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }
        public List<Region> RegionList()
        {
            return context.Regions.ToList();
        }

        public void Update(User user)
        {
            context.Users.Update(user);

            context.SaveChanges();
        }

        public UserEditViewModel UpdateUser(User updateuser)
        {
            UserEditViewModel newupdate = new UserEditViewModel
            {
                UserId = updateuser.UserId,

                FirstName = updateuser.FirstName,

                LastName = updateuser.LastName,

                MiddleName = updateuser.MiddleName,

                Email = updateuser.Email,

                PassportNumber = updateuser.PassportNumber,

                BirthDate = updateuser.BirthDate,

                CreateDate = updateuser.CreateDate,

                RegionId = updateuser.RegionId,

                UserTypeId = (int)updateuser.UserTypeId,

                InforTranId = updateuser.InformatTrId
            };

            return newupdate;
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

        public async Task<User> UserReturn(LoginViewModel model)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

        }

        public async Task<bool> VerifyPassword(string Password, byte[] passworHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                for (int i = 0; i < computedhash.Length; i++)
                {
                    if (computedhash[i] != passworHash[i])
                        return false;
                }

            }
            return true;
        }
      
        public List<UserType> UserTypeList()
        {
            return context.UserTypes.ToList();
        }

        public IEnumerable<MapIndexViewModel> gets()
        {
            var model = (from u in context.Users
                         join m in context.RoleMaps
                         on u.UserId equals m.UserId
                         join r in context.Roles
                         on m.RoleId equals r.Id
                         where r.RoleName == "Superadmin"
                         select new MapIndexViewModel
                         {
                             UserName = u.Email
                         });
            return model.ToArray();
        }

        public IEnumerable<MapIndexViewModel> getss()
        {
            var model = (from u in context.Users
                         join m in context.RoleMaps
                         on u.UserId equals m.UserId
                         join r in context.Roles
                         on m.RoleId equals r.Id
                         where r.RoleName == "admin"
                         select new MapIndexViewModel
                         {
                             UserName = u.Email
                         });
            return model.ToArray();
        }

        public async Task<User> changereturn(ChangeModel model)
        {
            return await context.Users.Where(x => x.Email == model.Email).FirstOrDefaultAsync();
        }

        public async Task<User> CreateChangeAsync(User user, ChangeModel model)
        {

            byte[] passwordHash, passwordSalt;

            CreatePassworHash(model.NewPassword, out passwordHash, out passwordSalt);

            user.FirstName = user.FirstName;
            user.LastName = user.LastName;
            user.MiddleName = user.MiddleName;
            user.Email = user.Email;
            user.PassportNumber = user.PassportNumber;
            user.BirthDate = user.BirthDate;
            user.CreateDate = user.CreateDate;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return user;
        }

        public User NewUser(UserCreateViewModel newuser)
        {
            throw new NotImplementedException();
        }
    }
}

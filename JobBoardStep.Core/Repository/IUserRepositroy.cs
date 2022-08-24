using JobBoardStep.Core.Models;
using JobBoardStep.Core.ViewModel;
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

        void Create(User user);

        void Update(User user);

        void Delete(int id);

        IList<UserListViewModel> UserList(string lang);

        List<InformationTranslate> InfroList(string lang);

        List<Region> RegionList();

        List<UserType> UserTypeList();

        User NewUser(string UniqueFileName,UserCreateViewModel newuser);

        User NewUser1(RegestirViewModel model);

        UserEditViewModel UpdateUser(User updateuser);

        User ExsingUser(User exstinguser, UserEditViewModel user);

        Task<User> UserReturn(LoginViewModel model);

        Task<User> UserReturn1(Login1ViewModel model);

        Task<bool> VerifyPassword(string Password, byte[] passworHash, byte[] passwordSalt);

        IEnumerable<MapIndexViewModel> gets();

        IEnumerable<MapIndexViewModel> getss();

        Task<User> changereturn(ChangeModel model);

        Task<User> CreateChangeAsync(User user, ChangeModel model);


    }
}

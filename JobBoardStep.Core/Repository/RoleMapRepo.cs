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
    public class RoleMapRepo : IRoleMapRepo
    {
        private readonly AppDbContext context;

        public RoleMapRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(RoleMapViewModel maping)
        {
            RoleMap newrolemap = new RoleMap
            {
                RoleId = maping.RoleId,
                UserId = maping.UserId,
            };
            await context.RoleMaps.AddAsync(newrolemap);
            await context.SaveChangesAsync();
        }


        public List<MapIndexViewModel> GetAll()
        {
            var model = (from u in context.Users
                         join m in context.RoleMaps
                         on u.UserId equals m.UserId
                         join r in context.Roles
                         on m.RoleId equals r.Id
                         select new MapIndexViewModel
                         {
                             FirstName = u.FirstName,
                             UserName = u.Email,
                             RoleName = r.RoleName
                         });
            return model.ToList();
        }

        public List<Role> listrole()
        {
            return context.Roles.ToList();
        }

        public List<User> listuser()
        {
            return context.Users.ToList();
        }

        public Task UpdateAsync(RoleMap roleMap)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(RoleMap roleMap)
        {
            throw new NotImplementedException();
        }
    }
}

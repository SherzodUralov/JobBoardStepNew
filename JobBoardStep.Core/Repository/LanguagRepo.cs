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
    public class LanguagRepo : ILanguagRepo
    {
        private readonly AppDbContext context;

        public LanguagRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task Create(Language language)
        {
             await context.AddAsync(language);

             await context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Language> GetAll()
        {

          return  context.Languages;

            //if (!string.IsNullOrEmpty(out searchString))
            //{
            //    model = model.Where(x => x.LanguageName.Contains(out searchString));
            //}

        }

        public async Task<Language> GetById(int id)
        {
            return await context.Languages.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task Update(Language language)
        {
            context.Languages.Update(language);

            await context.SaveChangesAsync();
        }
    }
}

using JobBoardStep.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTypeTranslate>()
                .HasOne(x => x.Language)
                .WithMany(t => t.JobTypeTranslates)
                .HasForeignKey(w => w.LanguageId);

            modelBuilder.Entity<JobTypeTranslate>()
               .HasOne(x => x.JobType)
               .WithMany(t => t.JobTypeTranslates)
               .HasForeignKey(w => w.JobTypeId);

            modelBuilder.Entity<JobCategoryTranslate>()
               .HasOne(x => x.Language)
               .WithMany(t => t.JobCategoryTranslates)
               .HasForeignKey(w => w.LanguageId);

            modelBuilder.Entity<JobCategoryTranslate>()
               .HasOne(x => x.JobCategory)
               .WithMany(t => t.JobCategoryTranslates)
               .HasForeignKey(w => w.JobCatId);

            modelBuilder.Entity<ExperienceTranslate>()
               .HasOne(x => x.Language)
               .WithMany(t => t.ExperienceTranslates)
               .HasForeignKey(w => w.LanguageId);

            modelBuilder.Entity<ExperienceTranslate>()
              .HasOne(x => x.Experience)
              .WithMany(t => t.ExperienceTranslates)
              .HasForeignKey(w => w.ExperienceId);

            modelBuilder.Entity<InformationTranslate>()
              .HasOne(x => x.Language)
              .WithMany(t => t.InformationTranslates)
              .HasForeignKey(w => w.LanguageId);

            modelBuilder.Entity<InformationTranslate>()
              .HasOne(x => x.Information)
              .WithMany(t => t.InformationTranslates)
              .HasForeignKey(w => w.InformationId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Models.Application> Applications { get; set; }
        public DbSet<ExperienceTranslate> ExperienceTranslates { get; set; }
        public DbSet<Information> Information { get; set; }
        public DbSet<InformationTranslate> InformationTranslates { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobCategoryTranslate> JobCategoryTranslates { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<JobTypeTranslate> JobTypeTranslates { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}

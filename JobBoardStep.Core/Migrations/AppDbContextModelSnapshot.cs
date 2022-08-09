﻿// <auto-generated />
using System;
using JobBoardStep.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobBoardStep.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("JobBoardStep.Core.Models.Application", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("ApplicationStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FilePath")
                        .HasColumnType("longtext");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationId");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CareateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("ExperienceStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.ExperienceTranslate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("LanguageId");

                    b.ToTable("ExperienceTranslates");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Information", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("InformationStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Information");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.InformationTranslate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("InformationId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("InformationId");

                    b.HasIndex("LanguageId");

                    b.ToTable("InformationTranslates");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CareateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ExperTId")
                        .HasColumnType("int");

                    b.Property<int>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<int>("JobCatTId")
                        .HasColumnType("int");

                    b.Property<int>("JobCateId")
                        .HasColumnType("int");

                    b.Property<int>("JobTypeId")
                        .HasColumnType("int");

                    b.Property<int>("JobTypeTId")
                        .HasColumnType("int");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.HasIndex("ExperTId");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("JobCatTId");

                    b.HasIndex("JobCateId");

                    b.HasIndex("JobTypeId");

                    b.HasIndex("JobTypeTId");

                    b.HasIndex("UserId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.JobCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("JobCategories");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.JobCategoryTranslate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("JobCatId")
                        .HasColumnType("int");

                    b.Property<string>("JobCatName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobCatId");

                    b.HasIndex("LanguageId");

                    b.ToTable("JobCategoryTranslates");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.JobType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CareateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("JobTypeStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("JobTypes");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.JobTypeTranslate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("JobTypeId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("JobTypeId");

                    b.HasIndex("LanguageId");

                    b.ToTable("JobTypeTranslates");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LanguageStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("RegionStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.RoleMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleMaps");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("InformatTrId")
                        .HasColumnType("int");

                    b.Property<int?>("InformationId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int?>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("InformatTrId");

                    b.HasIndex("InformationId");

                    b.HasIndex("RegionId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserTypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Application", b =>
                {
                    b.HasOne("JobBoardStep.Core.Models.Job", "Job")
                        .WithMany("Application")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.User", "Users")
                        .WithMany("Applications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.ExperienceTranslate", b =>
                {
                    b.HasOne("JobBoardStep.Core.Models.Experience", "Experience")
                        .WithMany("ExperienceTranslates")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.Language", "Language")
                        .WithMany("ExperienceTranslates")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experience");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.InformationTranslate", b =>
                {
                    b.HasOne("JobBoardStep.Core.Models.Information", "Information")
                        .WithMany("InformationTranslates")
                        .HasForeignKey("InformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.Language", "Language")
                        .WithMany("InformationTranslates")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Information");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Job", b =>
                {
                    b.HasOne("JobBoardStep.Core.Models.ExperienceTranslate", "ExperienceTranslate")
                        .WithMany("Jobs")
                        .HasForeignKey("ExperTId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.Experience", "Experience")
                        .WithMany("Jobs")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.JobCategoryTranslate", "JobCategoryTranslate")
                        .WithMany("Jobs")
                        .HasForeignKey("JobCatTId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.JobCategory", "JobCategory")
                        .WithMany("Jobs")
                        .HasForeignKey("JobCateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.JobType", "JobType")
                        .WithMany("Jobs")
                        .HasForeignKey("JobTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.JobTypeTranslate", "JobTypeTranslate")
                        .WithMany("Jobs")
                        .HasForeignKey("JobTypeTId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.User", "User")
                        .WithMany("Jobs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experience");

                    b.Navigation("ExperienceTranslate");

                    b.Navigation("JobCategory");

                    b.Navigation("JobCategoryTranslate");

                    b.Navigation("JobType");

                    b.Navigation("JobTypeTranslate");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.JobCategoryTranslate", b =>
                {
                    b.HasOne("JobBoardStep.Core.Models.JobCategory", "JobCategory")
                        .WithMany("JobCategoryTranslates")
                        .HasForeignKey("JobCatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.Language", "Language")
                        .WithMany("JobCategoryTranslates")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobCategory");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.JobTypeTranslate", b =>
                {
                    b.HasOne("JobBoardStep.Core.Models.JobType", "JobType")
                        .WithMany("JobTypeTranslates")
                        .HasForeignKey("JobTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.Language", "Language")
                        .WithMany("JobTypeTranslates")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobType");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.RoleMap", b =>
                {
                    b.HasOne("JobBoardStep.Core.Models.Role", "Role")
                        .WithMany("RoleMaps")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.User", "User")
                        .WithMany("RoleMaps")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.User", b =>
                {
                    b.HasOne("JobBoardStep.Core.Models.InformationTranslate", "InformationTranslate")
                        .WithMany("Users")
                        .HasForeignKey("InformatTrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.Information", "Information")
                        .WithMany("Users")
                        .HasForeignKey("InformationId");

                    b.HasOne("JobBoardStep.Core.Models.Region", "Region")
                        .WithMany("Users")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardStep.Core.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId");

                    b.Navigation("Information");

                    b.Navigation("InformationTranslate");

                    b.Navigation("Region");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Experience", b =>
                {
                    b.Navigation("ExperienceTranslates");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.ExperienceTranslate", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Information", b =>
                {
                    b.Navigation("InformationTranslates");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.InformationTranslate", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Job", b =>
                {
                    b.Navigation("Application");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.JobCategory", b =>
                {
                    b.Navigation("JobCategoryTranslates");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.JobCategoryTranslate", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.JobType", b =>
                {
                    b.Navigation("JobTypeTranslates");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.JobTypeTranslate", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Language", b =>
                {
                    b.Navigation("ExperienceTranslates");

                    b.Navigation("InformationTranslates");

                    b.Navigation("JobCategoryTranslates");

                    b.Navigation("JobTypeTranslates");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Region", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.Role", b =>
                {
                    b.Navigation("RoleMaps");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Jobs");

                    b.Navigation("RoleMaps");
                });

            modelBuilder.Entity("JobBoardStep.Core.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

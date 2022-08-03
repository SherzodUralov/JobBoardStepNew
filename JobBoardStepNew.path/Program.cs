using JobBoardStep.Core.Context;
using JobBoardStep.Core.Repository;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//<Language>
builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
builder.Services.AddMvc().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(
    opt =>
    {
        var supportedCulteres = new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("uz"),
            new CultureInfo("ru")

        };
        opt.DefaultRequestCulture = new RequestCulture("uz");
        opt.SupportedCultures = supportedCulteres;
        opt.SupportedUICultures = supportedCulteres;
    });


//</Language>

builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddScoped<IInformationRepo, InformationRepo>();
builder.Services.AddScoped<IUserRepositroy, UserRepository>();
builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
builder.Services.AddScoped<IJobTypeRepository, JobTypeRepository>();
builder.Services.AddScoped<IExperienceRepo, ExperienceRepo>();
builder.Services.AddScoped<IJobRepository,JobRepository>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//<Language>
    app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

  //var supportedCultres = new[] { "en", "fr", "es" };
  //var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultres[0])
  //.AddSupportedCultures(supportedCultres)
  //.AddSupportedUICultures(supportedCultres);  
  // app.UseRequestLocalization(localizationOptions);


//</Language>


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using JobBoardStep.Core.Context;
using JobBoardStep.Core.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
builder.Services.AddMvc().AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(
    opt =>
    {
        var supportedCulteres = new List<CultureInfo>
        {
            
            new CultureInfo("rus"),
            new CultureInfo("eng"),
            new CultureInfo("uzb")

        };
        opt.DefaultRequestCulture = new RequestCulture("en");
        opt.SupportedCultures = supportedCulteres;
        opt.SupportedUICultures = supportedCulteres;
    });


builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

    // options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme; 
})
                 .AddCookie(options =>
                 {
                     options.LoginPath = "/Admin/Login";
                     options.AccessDeniedPath = "/User/Denied";
                     options.ExpireTimeSpan = TimeSpan.FromSeconds(200);
                 });   //.AddGoogle(options =>
                 //    {
                 //    //options.ClientId = "811395501239-m2ec6bl92v5ehs9v8sfrdt26ogh7gc8m.apps.googleusercontent.com";
                 //    //options.ClientSecret = "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";
                 //    //options.CallbackPath = "/authn";
                 //    //options.AuthorizationEndpoint += "?prompt=consent";
                 //});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
                 {
                     options.Cookie.Name = ".NetEscapades.Session";
                     options.IdleTimeout = TimeSpan.FromMinutes(30);
                     options.Cookie.IsEssential = true;
                 });

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
builder.Services.AddScoped<IRoleMapRepo, RoleMapRepo>();
builder.Services.AddScoped<ILanguagRepo, LanguagRepo>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();

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

app.UseAuthentication();
app.UseAuthorization();

    app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);


app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Job}/{action=List}/{id?}");

app.Run();

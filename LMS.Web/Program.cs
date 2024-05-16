using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using AutoMapper;
using LMS.Business;
using LMS.Business.Infrastructure.AutoMapper;
using LMS.Domain.Entities;
using LMS.Domain.Interface;
using LMS.External;
using LMS.Persistence;
using LMS.Web.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddNewtonsoftJson();



builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>()
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR"),
        
    };

    options.DefaultRequestCulture = new RequestCulture(supportedCultures.First());
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});


builder.Services.AddSingleton<SharedViewLocalizer>();

//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//    options.CheckConsentNeeded = context => true;
//    options.MinimumSameSitePolicy = SameSiteMode.None;
//});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();



builder.Services.AddDefaultIdentity<ApplicationUser>()
   .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<CookieTempDataProviderOptions>(options => { options.Cookie.IsEssential = true; });
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IUserHttpContextProvider, UserHttpContextProvider>();
builder.Services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
builder.Services.AddHttpClient();
builder.Services.AddScheduledTasks();


builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 1;
    options.Password.RequiredUniqueChars = 0;
});

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
try
{
    logger.Debug("init main");
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();
}
catch (Exception ex)
{
    //NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}

var app = builder.Build();
var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseDatabaseErrorPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();



//namespace Focus.Web
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            // NLog: setup the logger first to catch all errors
//            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
//            try
//            {
//                logger.Debug("init main");
//                CreateWebHostBuilder(args).Build().Run();
//            }
//            catch (Exception ex)
//            {
//                //NLog: catch setup errors
//                logger.Error(ex, "Stopped program because of exception");
//                throw;
//            }
//            finally
//            {
//                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
//                NLog.LogManager.Shutdown();
//            }
//        }

        
//        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args)
//                .UseStartup<Startup>()
//                .ConfigureLogging(logging =>
//                {
//                    logging.ClearProviders();
//                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
//                })
//                .UseNLog();  // NLog: setup NLog for Dependency injection
//    }
//}

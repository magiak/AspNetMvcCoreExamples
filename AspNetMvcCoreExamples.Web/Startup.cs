using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetMvcCoreExamples.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNetMvcCoreExamples.Web.Controllers;
using AspNetMvcCoreExamples.Web.Middlewares;
using Microsoft.AspNetCore.Authorization;
using AspNetMvcCoreExamples.Business.Security.Requirements;
using AspNetMvcCoreExamples.Business.Security;
using AspNetMvcCoreExamples.Business.Security.Handlers;
using System;
using Microsoft.AspNetCore.Authentication;
using AspNetMvcCoreExamples.Business.Security.ClaimsTransformers;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace AspNetMvcCoreExamples.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddAutoMapper();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            });

            // Configure your policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AtLeast21", policy =>
                    policy.Requirements.Add(new MinimumAgeRequirement(21)));

                options.AddPolicy("IsAdmin", policy => policy.RequireClaim("Admin"));
            });

            // Add all of your handlers to DI.
            services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            services.AddTransient<IClaimsTransformation, ClaimsTransformer>();

            //services.AddSingleton(this.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            //services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ViewModel>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
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

            // https://localhost:44335/StaticFiles/readme.md
            // https://localhost:44335/StaticFiles/ExcelExample.xlsx
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
                RequestPath = "/StaticFiles",
                OnPrepareResponse = ctx =>
                {
                    // Requires the following import:
                    // using Microsoft.AspNetCore.Http;
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age=60"); // "max-age" This directive specifies the maximum time in seconds that the fetched response is allowed to be reused from the time of the request. For example, "max-age=60" indicates that the response can be cached and reused for the next 60 seconds.
                },
                
            });

            // https://localhost:44335/StaticFiles
            // https://localhost:44335/wwwroot -> NotFound 404
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
                RequestPath = "/StaticFiles"
            });

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // app.UseMyMiddleware();

            app.UseEndpoints(endpoints => {
                //endpoints.MapControllerRoute(
                //    name: "default_cs",
                //    pattern: "cs/{controller=Home}/Prehled/{id?}",
                //    defaults: new { action = "Index", lang = "cs" });

                //endpoints.MapControllerRoute(
                //    name: "default_en",
                //    pattern: "en/{controller=Home}/Index/{id?}",
                //    defaults: new { action = "Index", lang = "en" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages(); // .NET Core 3.0 identity support
            });
        }
    }
}

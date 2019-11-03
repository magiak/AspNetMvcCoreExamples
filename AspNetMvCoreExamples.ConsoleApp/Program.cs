using AspNetMvcCoreExamples.Web.Data;
using AspNetMvCoreExamples.ConsoleApp.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AspNetMvCoreExamples.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              //.AddUserSecrets("") // Microsoft.Extensions.Configuration.UserSecrets
              .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var services = new ServiceCollection()
                .AddTransient<IApplicationCompositionRoot, ApplicationCompositionRoot>();

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IEntityFrameworkTests, EntityFrameworkTests>();
            services.AddLogging(cfg => cfg.AddConsole());
              
            var serviceProvider = services.BuildServiceProvider();
            var application = serviceProvider.GetService<IApplicationCompositionRoot>();

            application.Start();

            Console.ReadKey();
        }
    }
}

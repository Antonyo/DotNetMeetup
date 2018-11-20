using DotNetMeetup.Blazor.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace DotNetMeetup.Blazor.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitializeServices(BuildWebHost(args)).Run();
        }

        static IWebHost InitializeServices(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                ConfigureDataContext(services);
            }

            return host;

            void ConfigureDataContext(IServiceProvider services)
            {
                try
                {
                    DatabaseSeeder.Seed(services.GetService<AppDataContext>());
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<Startup>()
                .Build();
    }
}

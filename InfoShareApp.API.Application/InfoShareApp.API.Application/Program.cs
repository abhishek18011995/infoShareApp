using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using InfoShareApp.API.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using InfoShareApp.API.Common.Services.Logging;

namespace InfoShareApp.API.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            
            try
            {
                host.Run();
            } catch(Exception ex)
            {
                var logger = host.Services.GetRequiredService<ILogger<Program>>();
                logger.LogCritical(LoggingEvents.AppStartFailure, ex, "Error occured in Main");
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging()
                .UseStartup<Startup>();
    }
}

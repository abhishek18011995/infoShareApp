using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoShareApp.API.Application.Extensions
{
    public static class Extensions
    {
        // Extension method for configure logging 
        // Getting the configuration of logging from configuration file app.settings
        public static IWebHostBuilder ConfigureLogging(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
                //logging.AddEventSourceLogger();
            });

            return webHostBuilder;
        }
    }
}

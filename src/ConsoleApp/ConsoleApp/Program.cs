﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ConsoleApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Console = ConsoleApp.Classes.Console;

namespace ConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            #region Initialization
            // Configuration: Managed by Host.CreateDefaultBuilder
            var host = CreateHostBuilder(args).Build();
            #endregion

            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Program started");

            var console = host.Services.GetRequiredService<IConsole>();
            
            await console.RunAsync();

            //await host.RunAsync();

            logger.LogInformation("Program finished");
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            // Ref: https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.host.createdefaultbuilder?view=dotnet-plat-ext-7.0
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services
                        .AddTransient<IConsole, Console>();
                })
                .ConfigureLogging((_, logging) =>
                {
                    logging.ClearProviders();  // Clear existing providers
                    
                    // Add log providers:
                    logging.AddSimpleConsole(options =>
                    {
                        // Ref: https://learn.microsoft.com/en-us/dotnet/core/extensions/console-log-formatter
                        options.IncludeScopes = true;
                        options.SingleLine = true;
                        options.TimestampFormat = "yyy-MM-dd HH:mm:ss.fff ";
                    });
                });
    }
}
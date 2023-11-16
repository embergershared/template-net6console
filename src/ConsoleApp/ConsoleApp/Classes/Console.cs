using System.Threading.Tasks;
using ConsoleApp.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static System.Console;


namespace ConsoleApp.Classes
{
    internal class Console : IConsole
    {
        private readonly ILogger<Console> _logger;
        private IConfiguration _config;

        public Console(
            ILogger<Console> logger,
            IConfiguration config
        )
        {
            _logger = logger;
            _config = config;
        }

        public async Task RunAsync()
        {
            using (_logger.BeginScope("RunAsync()"))
            {
                _logger.LogTrace("Method start");

                WriteLine("Hello, World!");

                // await DoSomethingAsync()

                WriteLine($"Press Enter to exit....");
                ReadLine();

                _logger.LogTrace("Method end");
            }

        }
    }
}

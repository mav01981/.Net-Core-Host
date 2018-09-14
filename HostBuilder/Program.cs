using IHostBuilderAsConsole;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;

namespace HostBuilderServices
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var rootDir = Environment.CurrentDirectory.ToString();

            Console.WriteLine($"Logging Directory: {rootDir + $@"\{string.Format("{0:yyMMdd}", DateTime.Now)}.txt"}");

            var host = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.AddEnvironmentVariables();
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddCommandLine(args);
                })
                 .ConfigureServices((hostContext, services) =>
                 {
                     services.Configure<Appsettings>(new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false)
                        .Build());

                     Log.Logger = new LoggerConfiguration()
                     .WriteTo
                     .RollingFile("log-{Date}.txt")
                     .CreateLogger();

                     #region snippet1
                     services.AddHostedService<TimedHostedService>();
                     services.AddHostedService<ConsumeScopedServiceHostedService>();
                     services.AddScoped<ScopedProcessingService>();
                     #endregion
                 })
                 .UseConsoleLifetime()
                 .UseSerilog()
                 .Build();

            using (host)
            {
                Log.Information("Starting host");

                await host.StartAsync();

                await host.WaitForShutdownAsync();
            }
        }
    }
}

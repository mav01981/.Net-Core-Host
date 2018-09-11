using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace IHostService
{
    class Program
    {
         static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ServiceA>();
                    services.AddHostedService<ServiceB>();
                });

            await builder.RunConsoleAsync();
        }
    }
}

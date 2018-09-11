using System;
using System.Threading;
using System.Threading.Tasks;

namespace IHostService
{
    internal class ServiceB : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("MyServiceB is starting.");

            stoppingToken.Register(() => Console.WriteLine("MyServiceB is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("MyServiceB is doing background work.");

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            Console.WriteLine("MyServiceB background task is stopping.");
        }
    }
}
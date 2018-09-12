using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IHostService
{
    internal class TimedHostedService : IHostedService, IDisposable
    {
        private Timer _timer;

        public TimedHostedService()
        {
 
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {


            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
     
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {


            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
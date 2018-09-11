using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostBuilderServices
{
    internal class TimedHostedService : IHostedService, IDisposable
    {
        private readonly Appsettings settings;
        private SQLHelper sqlhelper;
        private Timer _timer;

        public TimedHostedService(IOptions<Appsettings> settings)
        {
            this.settings = settings.Value;
            sqlhelper = new SQLHelper(this.settings.SqlConnectionString);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Information("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(this.settings.Timer));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Log.Information("Event Fired......");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
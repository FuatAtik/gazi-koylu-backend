using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taigate.Cms.Infrastructure;
using Taigate.Core.Cache;
using Taigate.Data.Service;

namespace Taigate.Cms.Services
{
    public class RunAtOnProjectStartService :IHostedService
    {
        public readonly IServiceProvider _serviceProvider;

        public RunAtOnProjectStartService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            
            var scopedProcessingService =
                scope.ServiceProvider.GetRequiredService<ICustomDbCache>();

                await scopedProcessingService.GetOrCreateMongoSearchStringCache("mobilya",1,6);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
using Domic.Core.Common.ClassConsts;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.WebAPI.Commons.Jobs;

public class ProducerEventJob : IHostedService, IDisposable
{
    private readonly IMessageBroker _messageBroker;

    private Timer _timer;
    
    public ProducerEventJob(IMessageBroker messageBroker) => _messageBroker = messageBroker;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _messageBroker.NameOfAction  = nameof(ProducerEventJob);
        _messageBroker.NameOfService = Service.TemplateService;
        
        //_timer = new Timer(state => _messageBroker.Publish(), null, TimeSpan.Zero, TimeSpan.FromSeconds(15));
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0); //Reset
        
        return Task.CompletedTask;
    }

    public void Dispose() => _timer?.Dispose();
}
using Domic.Core.Common.ClassConsts;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.WebAPI.Frameworks.Jobs;

public class EventConsumerJob : IHostedService
{
    private readonly IMessageBroker _messageBroker;
    private readonly IConfiguration _configuration;

    public EventConsumerJob(IMessageBroker messageBroker, IConfiguration configuration)
    {
        _messageBroker = messageBroker;
        _configuration = configuration;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _messageBroker.NameOfService = Service.TemplateService;
        
        //User
        //_messageBroker.Subscribe<UserCreated, UserUpdated, UserDeleted>(queueOfUser);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
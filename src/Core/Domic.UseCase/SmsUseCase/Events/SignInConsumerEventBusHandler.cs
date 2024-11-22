using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Domain.Service.Entities;
using Domic.Domain.Sms.Events;
using Domic.UseCase.SmsUseCase.Contracts.Interfaces;
using Domic.UseCase.SmsUseCase.DTOs;

namespace Domic.UseCase.SmsUseCase.Events;

public class SignInConsumerEventBus : IConsumerEventBusHandler<UserLogined>
{
    private readonly ISmsProvider _smsProvider;
    private readonly ISmsDeliveryCommandRepository _smsDeliveryCommandRepository;
    private readonly IGlobalUniqueIdGenerator _globalUniqueIdGenerator;
    private readonly IDateTime _dateTime;

    public SignInConsumerEventBus(ISmsProvider smsProvider,
        ISmsDeliveryCommandRepository smsDeliveryCommandRepository, IGlobalUniqueIdGenerator globalUniqueIdGenerator,
        IDateTime dateTime
    )
    {
        _smsProvider = smsProvider;
        _smsDeliveryCommandRepository = smsDeliveryCommandRepository;
        _globalUniqueIdGenerator = globalUniqueIdGenerator;
        _dateTime = dateTime;
    }

    public Task BeforeHandleAsync(UserLogined @event, CancellationToken cancellationToken) => Task.CompletedTask;

    [TransactionConfig(Type = TransactionType.Command)]
    public async Task HandleAsync(UserLogined @event, CancellationToken cancellationToken)
    {
        var payload = new SmsIrPayload {
            TemplateId = 10,
            Mobile = @event.PhoneNumber,
            Parameters = { new("CODE", @event.OtpCode) }
        };

        var result = await _smsProvider.SendAsync(payload, cancellationToken);
        
        _smsDeliveryCommandRepository.Add(
            new SmsDelivery(_globalUniqueIdGenerator, _dateTime, @event.PhoneNumber, result.LineNumber, 
                result.MessageId, result.MessageContent, result.DeliveryStatus
            )
        );
    }

    public Task AfterHandleAsync(UserLogined @event, CancellationToken cancellationToken) => Task.CompletedTask;
}
using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Domain.Service.Entities;
using Domic.Domain.User.Events;
using Domic.UseCase.SmsUseCase.Contracts.Interfaces;
using Domic.UseCase.SmsUseCase.DTOs;

namespace Domic.UseCase.SmsUseCase.Events;

public class CreateOtpLogConsumerEventHandler : IConsumerEventBusHandler<OtpLogCreated>
{
    private readonly ISmsProvider _smsProvider;
    private readonly ISmsDeliveryCommandRepository _smsDeliveryCommandRepository;
    private readonly IGlobalUniqueIdGenerator _globalUniqueIdGenerator;
    private readonly IDateTime _dateTime;

    public CreateOtpLogConsumerEventHandler(ISmsProvider smsProvider, 
        ISmsDeliveryCommandRepository smsDeliveryCommandRepository, IGlobalUniqueIdGenerator globalUniqueIdGenerator, 
        IDateTime dateTime
    )
    {
        _smsProvider = smsProvider;
        _smsDeliveryCommandRepository = smsDeliveryCommandRepository;
        _globalUniqueIdGenerator = globalUniqueIdGenerator;
        _dateTime = dateTime;
    }

    public Task BeforeHandleAsync(OtpLogCreated @event, CancellationToken cancellationToken)
        => Task.CompletedTask;

    [TransactionConfig(Type = TransactionType.Command)]
    public async Task HandleAsync(OtpLogCreated @event, CancellationToken cancellationToken)
    {
        var payload = new SmsIrPayload { TemplateId = 10, Mobile = @event.PhoneNumber };

        payload.Parameters = new Dictionary<string, string> {
            {"CODE", @event.MessageContent}
        };

        var result = await _smsProvider.SendAsync(payload, cancellationToken);
        
        _smsDeliveryCommandRepository.Add(
            new SmsDelivery(_globalUniqueIdGenerator, _dateTime, @event.PhoneNumber, result.LineNumber, 
                result.MessageId, result.MessageContent, result.DeliveryStatus
            )
        );
    }

    public Task AfterHandleAsync(OtpLogCreated @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}
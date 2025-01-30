using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Entities;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Domain.Service.Entities;
using Domic.Domain.User.Events;
using Domic.UseCase.Commons.DTOs;
using Domic.UseCase.SmsUseCase.Contracts.Interfaces;

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
        var payload = new Payload { PhoneNumber = @event.PhoneNumber, MessageContent = @event.MessageContent };

        var result = await _smsProvider.SendOtpCodeAsync(payload, cancellationToken);
        
        _smsDeliveryCommandRepository.Add(
            new SmsDelivery(_globalUniqueIdGenerator, _dateTime, @event.PhoneNumber, result.Data.LineNumber, 
                result.Data.MessageId, result.Data.MessageText, result.Data.DeliveryStatus, result.Message,
                result.Data.SendDateTime, result.Data.DeliveryDateTime, @event.CreatedBy, @event.CreatedRole
            )
        );
    }

    public Task AfterHandleAsync(OtpLogCreated @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}
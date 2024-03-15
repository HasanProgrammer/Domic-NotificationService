using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Commons.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Domain.Service.Entities;
using Domic.UseCase.SmsUseCase.Contracts.Interfaces;
using Domic.UseCase.SmsUseCase.DTOs;

namespace Domic.UseCase.SmsUseCase.Events;

[Consumer(Queue = "")]
public class SignInConsumerMessageBus : IConsumerMessageBusHandler<SignInMessage>
{
    private readonly ISmsProvider _smsProvider;
    private readonly ISmsDeliveryRepository _smsDeliveryRepository;
    private readonly IGlobalUniqueIdGenerator _globalUniqueIdGenerator;
    private readonly IDateTime _dateTime;

    public SignInConsumerMessageBus(ISmsProvider smsProvider, 
        ISmsDeliveryRepository smsDeliveryRepository, IGlobalUniqueIdGenerator globalUniqueIdGenerator, 
        IDateTime dateTime
    )
    {
        _smsProvider = smsProvider;
        _smsDeliveryRepository = smsDeliveryRepository;
        _globalUniqueIdGenerator = globalUniqueIdGenerator;
        _dateTime = dateTime;
    }

    public void Handle(SignInMessage message)
    {
        var payload = new SmsIrPayload {
            TemplateId = 10,
            Mobile = message.PhoneNumber,
            Parameters = { new("CODE", message.OtpCode) }
        };

        var result = _smsProvider.Send(payload);
        
        _smsDeliveryRepository.Add(
            new SmsDelivery(_globalUniqueIdGenerator, _dateTime, message.PhoneNumber, result.LineNumber, 
                result.MessageId, result.MessageContent, result.DeliveryStatus
            )
        );
    }
}
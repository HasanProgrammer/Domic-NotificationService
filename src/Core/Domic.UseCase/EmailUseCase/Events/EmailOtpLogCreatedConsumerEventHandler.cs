using Domic.Core.Common.ClassEnums;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Email.Contracts.Interfaces;
using Domic.Domain.Email.Entities;
using Domic.Domain.Email.Events;
using Domic.UseCase.Commons.DTOs;
using Domic.UseCase.EmailUseCase.Contracts.Interfaces;

namespace Domic.UseCase.EmailUseCase.Events;

public class EmailVerifyCodeCreatedConsumerEventHandler(
    IEmailDeliveryCommandRepository emailDeliveryCommandRepository,
    IEmailProvider emailProvider,
    IGlobalUniqueIdGenerator globalUniqueIdGenerator,
    IDateTime dateTime
) : IConsumerEventBusHandler<EmailOtpLogCreated>
{
    public Task BeforeHandleAsync(EmailOtpLogCreated @event, CancellationToken cancellationToken) 
        => Task.CompletedTask;

    [TransactionConfig(Type = TransactionType.Command)]
    public async Task HandleAsync(EmailOtpLogCreated @event, CancellationToken cancellationToken)
    {
        var mailPayload = new EmailPayload { EmailAddress = @event.EmailAddress, MessageContent = @event.MessageContent };
        
        var result = await emailProvider.SendVerifyCodeAsync(mailPayload, cancellationToken);

        var newEmail = new EmailDelivery(
            globalUniqueIdGenerator, dateTime, @event.EmailAddress, result, @event.CreatedBy, @event.CreatedRole
        );

        await emailDeliveryCommandRepository.AddAsync(newEmail, cancellationToken);
    }

    public Task AfterHandleAsync(EmailOtpLogCreated @event, CancellationToken cancellationToken)
        => Task.CompletedTask;
}
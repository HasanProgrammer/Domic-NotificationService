using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Email.Contracts.Interfaces;
using Domic.Domain.Email.Entities;
using Domic.UseCase.Commons.DTOs;
using Domic.UseCase.EmailUseCase.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Domic.UseCase.EmailUseCase.Commands.VerifyCode;

public class CreateVerifyCodeCommandHandler(
    IEmailDeliveryCommandRepository emailDeliveryCommandRepository,
    IEmailProvider emailProvider,
    IGlobalUniqueIdGenerator globalUniqueIdGenerator,
    ISerializer serializer,
    [FromKeyedServices("Http2")] IIdentityUser identityUser,
    IDateTime dateTime
) : ICommandHandler<CreateVerifyCodeCommand, bool>
{
    public Task BeforeHandleAsync(CreateVerifyCodeCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    [WithValidation]
    [WithTransaction]
    public async Task<bool> HandleAsync(CreateVerifyCodeCommand command, CancellationToken cancellationToken)
    {
        var verifyCode = Random.Shared.Next(1000, 9999).ToString();

        var mailPayload = new EmailPayload { MailAddress = command.EmailAddress, MessageContent = verifyCode };

        //todo: must be retriable this func!
        var result = await emailProvider.TrySendVerifyCodeAsync(mailPayload, cancellationToken);

        var newEmail = new EmailDelivery(
            globalUniqueIdGenerator, dateTime, identityUser, serializer, command.EmailAddress, result, verifyCode
        );

        await emailDeliveryCommandRepository.AddAsync(newEmail, cancellationToken);

        return true;
    }

    public Task AfterHandleAsync(CreateVerifyCodeCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}
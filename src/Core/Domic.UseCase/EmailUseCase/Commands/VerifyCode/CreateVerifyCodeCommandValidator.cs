using Domic.Core.Domain.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;

namespace Domic.UseCase.EmailUseCase.Commands.VerifyCode;

public class CreateVerifyCodeCommandValidator : IValidator<CreateVerifyCodeCommand>
{
    public Task<object> ValidateAsync(CreateVerifyCodeCommand input, CancellationToken cancellationToken)
    {
        if (!input.EmailAddress.IsValidEmail())
            throw new UseCaseException("پست الکترونیکی ارسالی معتبر نمی باشد!");

        return Task.FromResult(default(object));
    }
}
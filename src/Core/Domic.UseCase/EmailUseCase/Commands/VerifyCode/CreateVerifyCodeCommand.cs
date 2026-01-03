using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.EmailUseCase.Commands.VerifyCode;

public class CreateVerifyCodeCommand : ICommand<bool>
{
    public string EmailAddress { get; set; }
}
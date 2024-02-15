using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.SmsUseCase.Events;

public class OtpCodConsumerMessageBus : IConsumerMessageBusHandler<string>
{
    public void Handle(string message)
    {
        throw new NotImplementedException();
    }
}

using Domic.UseCase.Commons.DTOs;

namespace Domic.UseCase.SmsUseCase.Contracts.Interfaces;

public interface ISmsProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<Result> SendOtpCodeAsync(Payload payload, CancellationToken cancellationToken);
}
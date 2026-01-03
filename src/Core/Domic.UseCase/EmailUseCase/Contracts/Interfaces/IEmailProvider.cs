using Domic.UseCase.Commons.DTOs;

namespace Domic.UseCase.EmailUseCase.Contracts.Interfaces;

public interface IEmailProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<string> TrySendVerifyCodeAsync(EmailPayload payload, CancellationToken cancellationToken);
}
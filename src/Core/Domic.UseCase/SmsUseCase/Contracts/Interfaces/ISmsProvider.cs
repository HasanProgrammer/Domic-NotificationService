
using Domic.UseCase.Commons.DTOs;

namespace Domic.UseCase.SmsUseCase.Contracts.Interfaces;

public interface ISmsProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Result Send(Payload payload) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<Result> SendAsync(Payload payload, CancellationToken cancellationToken);
}
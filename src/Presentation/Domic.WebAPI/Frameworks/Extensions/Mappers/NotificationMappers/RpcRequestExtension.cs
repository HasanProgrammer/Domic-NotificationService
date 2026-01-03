using Domic.Core.Notification.Grpc;
using Domic.UseCase.EmailUseCase.Commands.VerifyCode;

namespace Domic.WebAPI.Frameworks.Extensions.Mappers.NotificationMappers;

//Query
public static partial class RpcRequestExtension
{
    
}

//Command
public partial class RpcRequestExtension
{
    /// <summary>
    /// Map ( CreateRequest ) -> ( CreateVerifyCodeCommand )
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static CreateVerifyCodeCommand MapToCreateCommand(this CreateRequest request)
        => new() { EmailAddress = request.EmailAddress.Value };
}
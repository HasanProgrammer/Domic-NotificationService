using Domic.Core.Common.ClassExtensions;
using Domic.Core.Notification.Grpc;

namespace Domic.WebAPI.Frameworks.Extensions.Mappers.NotificationMappers;

//Query
public static partial class RpcResponseExtension
{
    
}

//Command
public partial class RpcResponseExtension
{
    /// <summary>
    /// Map ( result ) -> CreateResponse
    /// </summary>
    /// <param name="result"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static CreateResponse MapToCreateResponse(this bool result, IConfiguration configuration)
        => new() {
              Code = result ? configuration.GetSuccessCreateStatusCode() : configuration.GetErrorStatusCode(),
              Message = result ? configuration.GetSuccessCreateMessage() : configuration.GetErrorCreateMessage(),
              Body = new CreateResponseBody { Result = result }
           };
}
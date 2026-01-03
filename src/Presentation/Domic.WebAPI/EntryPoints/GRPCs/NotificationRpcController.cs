using Domic.Core.Notification.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.WebAPI.Frameworks.Extensions.Mappers.NotificationMappers;
using Grpc.Core;

namespace Domic.WebAPI.EntryPoints.GRPCs;

public class NotificationRpcController(IMediator mediator, IConfiguration configuration) : NotificationService.NotificationServiceBase
{
    public override async Task<CreateResponse> Create(CreateRequest request, ServerCallContext context)
    {
        var result = await mediator.DispatchAsync(request.MapToCreateCommand(), context.CancellationToken);

        return result.MapToCreateResponse(configuration);
    }
}
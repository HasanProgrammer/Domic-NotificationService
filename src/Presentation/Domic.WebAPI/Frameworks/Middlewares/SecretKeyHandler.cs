using Grpc.Core;

namespace Domic.WebAPI.Frameworks.Middlewares;

public class SecretKeyHandler
{
    private readonly RequestDelegate _Next;
    private readonly IConfiguration  _Configuration;

    public SecretKeyHandler(RequestDelegate Next , IConfiguration Configuration)
    {
        _Next          = Next;
        _Configuration = Configuration;
    }

    public async Task Invoke(HttpContext Context)
    {
        if ( Context.Request.Headers.Any(header => header.Key.Equals("SecretKey")) )
            if( Context.Request.Headers["SecretKey"].ToString().Equals( _Configuration.GetValue<string>("SecretKey") ) )
                await _Next(Context);

        throw new RpcException(new Status(StatusCode.Unavailable, "You can not have a license to use the service directly !"));
    }
}
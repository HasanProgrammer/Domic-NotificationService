using Domic.Infrastructure.Implementations.UseCase.Services.SmsIr;
using Domic.UseCase.EmailUseCase.Contracts.Interfaces;
using Domic.UseCase.SmsUseCase.Contracts.Interfaces;

namespace Domic.WebAPI.Frameworks.Extensions;

public static class IApplicationBuilderExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void RegisterSmsProvider(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISmsProvider, SmsIrSmsProvider>();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void RegisterEmailProvider(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEmailProvider, LiaraEmailProvider>();
    }
}
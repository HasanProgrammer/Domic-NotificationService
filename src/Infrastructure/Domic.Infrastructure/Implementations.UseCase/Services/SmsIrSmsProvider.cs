#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

using System.Net.Http.Json;
using System.Text;
using Domic.Core.Infrastructure.Extensions;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.Commons.DTOs;
using Domic.UseCase.SmsUseCase.Contracts.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Domic.Infrastructure.Implementations.UseCase.Services.SmsIr;

public class SmsIrSmsProvider(ILogger logger, IConfiguration configuration) : ISmsProvider
{
    public async Task<Result> SendOtpCodeAsync(Payload payload, CancellationToken cancellationToken)
    {
        logger.RecordAsync(Guid.NewGuid().ToString(), "NotificationService", $"sms key: {Environment.GetEnvironmentVariable("SMS_IR_KEY")}", cancellationToken);
        
        using var httpClient = new HttpClient();
        
        httpClient.DefaultRequestHeaders.Add("x-api-key", Environment.GetEnvironmentVariable("SMS_IR_KEY"));
        
        var model = new VerifySendModel {
            Mobile = payload.PhoneNumber,
            TemplateId = 740119, //123456 ( Test )
            Parameters = new[] {
                new VerifySendParameterModel { Name = "CODE", Value = payload.MessageContent }
            }
        };
        
        StringContent stringContent = new(model.Serialize(), Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("https://api.sms.ir/v1/send/verify", stringContent);

        var result = await response.Content.ReadFromJsonAsync<VerifyResponse>(cancellationToken);
        
        logger.RecordAsync(Guid.NewGuid().ToString(), "NotificationService", $"result of send sms: {result.Serialize()}", cancellationToken);
        
        var responseReport = await httpClient.GetAsync($"https://api.sms.ir/v1/send/{result.Data.MessageId}");
        
        return await responseReport.Content.ReadFromJsonAsync<Result>();
    }
}

public class VerifySendParameterModel
{
    public string Name { get; set; }
    public string Value { get; set; }
}

public class VerifySendModel
{
    public string Mobile { get; set; }

    public int TemplateId { get; set; }

    public VerifySendParameterModel[] Parameters { get; set; }
}

public class VerifyResponse
{
    public int Status { get; set; } 
    public string Message { get; set; }
    public VerifyResponseData Data { get; set; }
}

public class VerifyResponseData
{
    public double Cost { get; set; }
    public int MessageId { get; set; }
}
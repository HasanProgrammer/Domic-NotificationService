using Domic.UseCase.Commons.DTOs;
using Domic.UseCase.SmsUseCase.Contracts.Interfaces;
using Domic.UseCase.SmsUseCase.DTOs;
using IPE.SmsIrClient.Models.Requests;

namespace Domic.Infrastructure.Implementations.UseCase.Services.SmsIr;

public class SmsIrSmsProvider : ISmsProvider
{
    public async Task<Result> SendAsync(Payload payload, CancellationToken cancellationToken)
    {
        var smsIrPayload = payload as SmsIrPayload;
        
        var smsIr = new IPE.SmsIrClient.SmsIr(Environment.GetEnvironmentVariable("SMS_IR_KEY"));

        List<VerifySendParameter> parameters = new();

        foreach (var (key, value) in smsIrPayload.Parameters)
            parameters.Add(new VerifySendParameter(key, value));

        var response = await smsIr.VerifySendAsync(smsIrPayload.Mobile, smsIrPayload.TemplateId, parameters.ToArray());

        return new() { MessageId = response.Data.MessageId };
    }
}
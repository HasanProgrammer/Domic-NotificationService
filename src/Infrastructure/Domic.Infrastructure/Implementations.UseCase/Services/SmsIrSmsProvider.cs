using Domic.UseCase.Commons.DTOs;
using Domic.UseCase.SmsUseCase.Contracts.Interfaces;
using Domic.UseCase.SmsUseCase.DTOs;
using IPE.SmsIrClient.Models.Requests;

namespace Domic.Infrastructure.Implementations.UseCase.Services.SmsIr;

public class SmsIrSmsProvider : ISmsProvider
{
    private readonly IPE.SmsIrClient.SmsIr _smsIr;

    public SmsIrSmsProvider() => _smsIr = new IPE.SmsIrClient.SmsIr(Environment.GetEnvironmentVariable("SMS_IR_KEY"));

    public Result Send(Payload payload)
    {
        var smsIrPayload = payload as SmsIrPayload;

        List<VerifySendParameter> parameters = new();

        foreach (var (key, value) in smsIrPayload.Parameters)
            parameters.Add(new VerifySendParameter(key, value));

        var response = _smsIr.VerifySend(smsIrPayload.Mobile, smsIrPayload.TemplateId, parameters.ToArray());

        var responseOfDeliveryInfo = _smsIr.GetReport(response.Data.MessageId).Data;

        return new() {
            LineNumber = responseOfDeliveryInfo.LineNumber,
            MessageId = responseOfDeliveryInfo.MessageId,
            MessageContent = responseOfDeliveryInfo.MessageText,
            SendDateTime = DateTime.Parse(responseOfDeliveryInfo.SendDateTime.ToString()),
            DeliveryStatus = responseOfDeliveryInfo.DeliveryState,
            DeliveryDateTime = responseOfDeliveryInfo.DeliveryDateTime is not null 
                ? DateTime.Parse(responseOfDeliveryInfo.DeliveryDateTime.ToString())
                : default
        };
    }

    public async Task<Result> SendAsync(Payload payload, CancellationToken cancellationToken)
    {
        var smsIrPayload = payload as SmsIrPayload;

        List<VerifySendParameter> parameters = new();

        foreach (var (key, value) in smsIrPayload.Parameters)
            parameters.Add(new VerifySendParameter(key, value));

        var response =
            await _smsIr.VerifySendAsync(smsIrPayload.Mobile, smsIrPayload.TemplateId, parameters.ToArray());

        var responseOfDeliveryInfo = ( await _smsIr.GetReportAsync(response.Data.MessageId) ).Data;

        return new() {
            LineNumber = responseOfDeliveryInfo.LineNumber,
            MessageId = responseOfDeliveryInfo.MessageId,
            MessageContent = responseOfDeliveryInfo.MessageText,
            SendDateTime = DateTime.Parse(responseOfDeliveryInfo.SendDateTime.ToString()),
            DeliveryStatus = responseOfDeliveryInfo.DeliveryState,
            DeliveryDateTime = responseOfDeliveryInfo.DeliveryDateTime is not null 
                ? DateTime.Parse(responseOfDeliveryInfo.DeliveryDateTime.ToString())
                : default
        };
    }
}
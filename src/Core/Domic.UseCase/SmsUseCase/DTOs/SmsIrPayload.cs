using Domic.UseCase.Commons.DTOs;

namespace Domic.UseCase.SmsUseCase.DTOs;

public class SmsIrPayload : Payload
{
    public int TemplateId { get; set; }
    public IDictionary<string, string> Parameters { get; set; }
}
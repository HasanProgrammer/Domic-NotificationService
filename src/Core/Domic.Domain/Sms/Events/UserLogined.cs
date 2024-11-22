using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Sms.Events;

[EventConfig(Queue = "")]
public class UserLogined : UpdateDomainEvent<string>
{
    public string PhoneNumber { get; set; }
    public string OtpCode { get; set; }
}
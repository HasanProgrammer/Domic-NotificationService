using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Sms.Events;

[EventConfig(Queue = "Notification_OtpLog_Queue")]
public class OtpLogCreated : CreateDomainEvent<string>
{
    public string PhoneNumber { get; init; }
    public string MessageContent { get; init; }
}
using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Email.Events;

[EventConfig(Queue = "Notification_EmailOtpLog_Queue")]
public class EmailOtpLogCreated : CreateDomainEvent<string>
{
    public string EmailAddress { get; set; }
    public string MessageContent { get; set; }
}
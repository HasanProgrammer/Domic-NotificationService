using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Email.Events;

[EventConfig(Queue = "Notification_EmailDelivery_Queue")]
public class EmailVerifyCodeCreated : CreateDomainEvent<string>
{
    public string EmailAddress { get; set; }
    public string VerifyCode { get; set; }
}
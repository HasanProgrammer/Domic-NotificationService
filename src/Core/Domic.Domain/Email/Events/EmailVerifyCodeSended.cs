using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Enumerations;

namespace Domic.Domain.Email.Events;

[EventConfig(ExchangeType = Exchange.FanOut, Exchange = "Notification_EmailDelivery_Exchange")]
public class EmailVerifyCodeSended : CreateDomainEvent<string>
{
    public string EmailAddress { get; set; }
    public string VerifyCode { get; set; }
}
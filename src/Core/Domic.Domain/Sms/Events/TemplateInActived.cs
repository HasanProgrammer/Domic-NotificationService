using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Service.Events;

public class TemplateInActived : IDomainEvent
{
    public string Id     { get; init; }
    public bool IsActive { get; init; }
}
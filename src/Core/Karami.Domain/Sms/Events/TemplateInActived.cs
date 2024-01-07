using Karami.Core.Domain.Contracts.Interfaces;

namespace Karami.Domain.Service.Events;

public class TemplateInActived : IDomainEvent
{
    public string Id     { get; init; }
    public bool IsActive { get; init; }
}
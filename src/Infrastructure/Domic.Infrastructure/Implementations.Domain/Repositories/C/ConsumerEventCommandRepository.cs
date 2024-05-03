using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Entities;
using Domic.Persistence.Contexts.C;
using Microsoft.EntityFrameworkCore;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

public class ConsumerEventCommandRepository(SQLContext context) : IConsumerEventCommandRepository
{
    public ConsumerEvent FindById(object id) 
        => context.ConsumerEvents.FirstOrDefault(@event => @event.Id == id as string);
    
    public Task<ConsumerEvent> FindByIdAsync(object id, CancellationToken cancellationToken) 
        => context.ConsumerEvents.FirstOrDefaultAsync(@event => @event.Id == id as string, cancellationToken);

    public void Add(ConsumerEvent entity) => context.ConsumerEvents.Add(entity);
}
using Karami.Core.Domain.Contracts.Interfaces;
using Karami.Core.Domain.Entities;
using Karami.Core.Domain.Enumerations;
using Karami.Persistence.Contexts.C;

namespace Karami.Infrastructure.Implementations.Domain.Repositories.C;

//Config
public partial class EventCommandRepository : IEventCommandRepository
{
    private readonly SQLContext _context;

    public EventCommandRepository(SQLContext context) => _context = context;
}

//Transaction
public partial class EventCommandRepository
{
    public async Task AddAsync(Event entity, CancellationToken cancellationToken) 
        => await _context.Events.AddAsync(entity, cancellationToken);

    public void Change(Event entity) => _context.Events.Update(entity);

    public void Remove(Event entity) => _context.Events.Remove(entity);
}

//Query
public partial class EventCommandRepository
{
    public IEnumerable<Event> FindAll() => _context.Events.ToList();

    public IEnumerable<Event> FindAllWithOrdering(Order order, bool accending = true)
    {
        var entity = _context.Events;

        return order switch {
            Order.Date => entity.OrderBy(@event => @event.CreatedAt_EnglishDate).ToList(),
            Order.Id   => entity.OrderBy(@event => @event.Id).ToList(),
            _ => null
        };
    }
}
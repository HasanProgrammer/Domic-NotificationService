using Domic.Domain.Email.Contracts.Interfaces;
using Domic.Domain.Email.Entities;
using Domic.Persistence.Contexts.C;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

public class EmailDeliveryCommandRepository : IEmailDeliveryCommandRepository
{
    private readonly SQLContext _sqlContext;

    public EmailDeliveryCommandRepository(SQLContext sqlContext) => _sqlContext = sqlContext;

    public Task AddAsync(EmailDelivery entity, CancellationToken cancellationToken)
    {
        _sqlContext.EmailDeliveries.Add(entity);
        
        return Task.CompletedTask;
    }
}
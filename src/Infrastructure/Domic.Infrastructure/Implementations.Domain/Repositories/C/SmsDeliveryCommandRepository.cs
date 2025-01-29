using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Domain.Service.Entities;
using Domic.Persistence.Contexts.C;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

public class SmsDeliveryCommandRepository : ISmsDeliveryCommandRepository
{
    private readonly SQLContext _sqlContext;

    public SmsDeliveryCommandRepository(SQLContext sqlContext) => _sqlContext = sqlContext;

    public void Add(SmsDelivery entity) => _sqlContext.SmsDeliveries.Add(entity);
}
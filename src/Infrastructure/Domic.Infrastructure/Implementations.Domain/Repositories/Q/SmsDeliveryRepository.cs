using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Persistence.Contexts.Q;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.Q;

public class SmsDeliveryRepository : ISmsDeliveryRepository
{
    private readonly SQLContext _sqlContext;

    public SmsDeliveryRepository(SQLContext sqlContext)
    {
        _sqlContext = sqlContext;
    }
}
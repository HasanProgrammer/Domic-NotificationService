using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Persistence.Contexts.Q;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.Q;

public class SmsQueryRepository : ISmsQueryRepository
{
    private readonly SQLContext _sqlContext;

    public SmsQueryRepository(SQLContext sqlContext)
    {
        _sqlContext = sqlContext;
    }
}
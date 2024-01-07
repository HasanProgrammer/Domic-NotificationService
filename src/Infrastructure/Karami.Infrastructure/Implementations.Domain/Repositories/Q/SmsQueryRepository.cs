using Karami.Domain.Service.Contracts.Interfaces;
using Karami.Persistence.Contexts.Q;

namespace Karami.Infrastructure.Implementations.Domain.Repositories.Q;

public class SmsQueryRepository : ISmsQueryRepository
{
    private readonly SQLContext _sqlContext;

    public SmsQueryRepository(SQLContext sqlContext)
    {
        _sqlContext = sqlContext;
    }
}
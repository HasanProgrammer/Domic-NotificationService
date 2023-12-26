using Karami.Domain.Service.Contracts.Interfaces;
using Karami.Persistence.Contexts;
using Karami.Persistence.Contexts.Q;

namespace Karami.Infrastructure.Implementations.Domain.Repositories.Q;

public class TemplateQueryRepository : ITemplateQueryRepository
{
    private readonly SQLContext _sqlContext;

    public TemplateQueryRepository(SQLContext sqlContext)
    {
        _sqlContext = sqlContext;
    }
}
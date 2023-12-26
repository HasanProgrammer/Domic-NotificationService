using Karami.Domain.Service.Contracts.Interfaces;
using Karami.Persistence.Contexts.C;

namespace Karami.Infrastructure.Implementations.Domain.Repositories.C;

public class TemplateCommandRepository : ITemplateCommandRepository
{
    private readonly SQLContext _sqlContext;

    public TemplateCommandRepository(SQLContext sqlContext)
    {
        _sqlContext = sqlContext;
    }
}
using Karami.Core.Domain.Contracts.Interfaces;
using Karami.Domain.Service.Entities;

namespace Karami.Domain.Service.Contracts.Interfaces;

public interface ITemplateQueryRepository : IQueryRepository<TemplateQuery, string>
{
    
}
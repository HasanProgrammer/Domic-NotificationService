using Karami.Core.Domain.Contracts.Interfaces;

namespace Karami.Domain.Service.Contracts.Interfaces;

public interface ISmsQueryRepository : IQueryRepository<Entities.SmsQuery, string>
{
    
}
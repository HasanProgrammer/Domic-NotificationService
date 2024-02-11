using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Service.Contracts.Interfaces;

public interface ISmsQueryRepository : IQueryRepository<Entities.SmsQuery, string>
{
    
}
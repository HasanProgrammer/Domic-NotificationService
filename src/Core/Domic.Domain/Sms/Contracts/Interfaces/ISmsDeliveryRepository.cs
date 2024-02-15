using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Service.Contracts.Interfaces;

public interface ISmsDeliveryRepository : ICommandRepository<Entities.SmsDelivery, string>
{
    
}
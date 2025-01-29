using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Service.Contracts.Interfaces;

public interface ISmsDeliveryCommandRepository : ICommandRepository<Entities.SmsDelivery, string>;
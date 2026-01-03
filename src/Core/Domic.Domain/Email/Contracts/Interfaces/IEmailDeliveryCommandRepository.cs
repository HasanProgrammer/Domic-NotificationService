using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Email.Contracts.Interfaces;

public interface IEmailDeliveryCommandRepository : ICommandRepository<Entities.EmailDelivery, string>;
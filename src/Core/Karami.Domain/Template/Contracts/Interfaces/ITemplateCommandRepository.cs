using Karami.Core.Domain.Contracts.Interfaces;

namespace Karami.Domain.Service.Contracts.Interfaces;

public interface ITemplateCommandRepository : ICommandRepository<Entities.Template, string>
{
    
}
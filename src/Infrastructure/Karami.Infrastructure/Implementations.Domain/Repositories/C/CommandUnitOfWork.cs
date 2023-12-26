using Karami.Core.Domain.Contracts.Interfaces;
using Karami.Domain.Commons.Contracts.Interfaces;
using Karami.Domain.Service.Contracts.Interfaces;
using Karami.Persistence.Contexts.C;
using Microsoft.Extensions.DependencyInjection;

namespace Karami.Infrastructure.Implementations.Domain.Repositories.C;

//Transactions
public partial class CommandUnitOfWork : ICommandUnitOfWork
{
    private readonly SQLContext       _context;
    private readonly IServiceProvider _serviceProvider;

    public CommandUnitOfWork(SQLContext context, IServiceProvider serviceProvider)
    {
        _context         = context; //Resource
        _serviceProvider = serviceProvider;
    }

    public void Transaction() => _context.Database.BeginTransaction(); //Resource

    public async Task TransactionAsync(CancellationToken cancellationToken) 
        => await _context.Database.BeginTransactionAsync(cancellationToken); //Resource

    public void Commit()
    {
        _context.SaveChanges();
        _context.Database.CommitTransaction();
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
        await _context.Database.CommitTransactionAsync(cancellationToken);
    }

    public void Rollback()
    {
        if (_context.Database.CurrentTransaction != null)
            _context.Database.RollbackTransaction();
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        if(_context.Database.CurrentTransaction != null)
            await _context.Database.RollbackTransactionAsync(cancellationToken);
    }

    public void Dispose() {}
}

//Repositories
public partial class CommandUnitOfWork
{
    public ITemplateCommandRepository TemplateCommandRepository()
        => _serviceProvider.GetRequiredService<ITemplateCommandRepository>();

    public IEventCommandRepository EventCommandRepository() 
        => _serviceProvider.GetRequiredService<IEventCommandRepository>();
}
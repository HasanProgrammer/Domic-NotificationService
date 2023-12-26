using Karami.Domain.Commons.Contracts.Interfaces;
using Karami.Persistence.Contexts.Q;
using Microsoft.EntityFrameworkCore.Storage;

namespace Karami.Infrastructure.Implementations.Domain.Repositories.Q;

//Transactions
public class QueryUnitOfWork : IQueryUnitOfWork
{
    private readonly SQLContext   _context;
    private IDbContextTransaction _transaction;
    public QueryUnitOfWork(SQLContext context) => _context = context; //Resource

    public void Transaction() => _transaction = _context.Database.BeginTransaction(); //Resource

    public async Task TransactionAsync(CancellationToken cancellationToken) 
        => _transaction = await _context.Database.BeginTransactionAsync(cancellationToken); //Resource

    public void Commit()
    {
        _context.SaveChanges();
        _transaction.Commit();
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
        await _transaction.CommitAsync(cancellationToken);
    }

    public void Rollback() => _transaction?.Rollback();

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        if (_transaction is not null)
            await _transaction.RollbackAsync(cancellationToken);
    }

    public void Dispose() => _transaction?.Dispose();
}
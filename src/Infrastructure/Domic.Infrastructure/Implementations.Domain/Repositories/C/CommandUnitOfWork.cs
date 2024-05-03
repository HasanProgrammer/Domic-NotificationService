using Domic.Domain.Commons.Contracts.Interfaces;
using Domic.Persistence.Contexts.C;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

//Transactions
public class CommandUnitOfWork : ICommandUnitOfWork
{
    private readonly SQLContext   _context;
    private IDbContextTransaction _transaction;
    
    public CommandUnitOfWork(SQLContext context) => _context = context; //Resource

    public void Transaction() => _transaction = _context.Database.BeginTransaction(); //Resource

    public void Commit()
    {
        _context.SaveChanges();
        _transaction.Commit();
    }

    public void Rollback() => _transaction?.Rollback();

    public void Dispose() => _transaction?.Dispose();
}
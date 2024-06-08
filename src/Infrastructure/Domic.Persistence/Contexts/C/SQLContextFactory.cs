using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Domic.Persistence.Contexts.C;

public class SQLContextFactory : IDesignTimeDbContextFactory<SQLContext>
{
    public SQLContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<SQLContext> builder = new DbContextOptionsBuilder<SQLContext>();
        
        builder.UseSqlServer("Somethings!");

        return new SQLContext(builder.Options);
    }
}
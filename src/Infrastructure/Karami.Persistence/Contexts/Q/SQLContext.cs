using Karami.Domain.Service.Entities;
using Karami.Persistence.Configs.Q;
using Microsoft.EntityFrameworkCore;

namespace Karami.Persistence.Contexts.Q;

/*Setting*/
public partial class SQLContext : DbContext
{
    public SQLContext(DbContextOptions<SQLContext> options) : base(options)
    {
        
    }
}

/*Entity*/
public partial class SQLContext
{
    public DbSet<SmsQuery> SMSs { get; set; }
}

/*Config*/
public partial class SQLContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfiguration(new SmsQueryConfig());
    }
}
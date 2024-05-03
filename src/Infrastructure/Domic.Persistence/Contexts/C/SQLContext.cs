using Domic.Core.Domain.Entities;
using Domic.Core.Persistence.Configs;
using Domic.Domain.Service.Entities;
using Domic.Persistence.Configs.C;
using Microsoft.EntityFrameworkCore;

namespace Domic.Persistence.Contexts.C;

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
    public DbSet<ConsumerEvent> ConsumerEvents { get; set; }
    public DbSet<SmsDelivery> SmsDeliveries { get; set; }
}

/*Config*/
public partial class SQLContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfiguration(new ConsumerEventConfig());
        builder.ApplyConfiguration(new SmsDeliveryConfig());
    }
}
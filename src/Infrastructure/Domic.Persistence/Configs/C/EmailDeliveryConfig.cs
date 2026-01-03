using Domic.Core.Persistence.Configs;
using Domic.Domain.Email.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domic.Persistence.Configs.C;

public class EmailDeliveryConfig : BaseEntityConfig<EmailDelivery, string>
{
    public override void Configure(EntityTypeBuilder<EmailDelivery> builder)
    {
        base.Configure(builder);
        
        /*-----------------------------------------------------------*/
        
        //Configs

        builder.ToTable("EmailDeliveries");

        builder.Property(delivery => delivery.MessageContent).IsRequired().HasMaxLength(150);
    }
}
using Domic.Core.Persistence.Configs;
using Domic.Domain.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domic.Persistence.Configs.C;

public class SmsDeliveryConfig : BaseEntityConfig<SmsDelivery, string>
{
    public override void Configure(EntityTypeBuilder<SmsDelivery> builder)
    {
        base.Configure(builder);
        
        /*-----------------------------------------------------------*/
        
        //Configs

        builder.ToTable("SmsDeliveries");

        builder.Property(delivery => delivery.PhoneNumber).IsRequired().HasMaxLength(12);
        builder.Property(delivery => delivery.LineNumber).IsRequired();
        builder.Property(delivery => delivery.MessageId).IsRequired();
        builder.Property(delivery => delivery.MessageContent).IsRequired().HasMaxLength(150);
        builder.Property(delivery => delivery.SendDateTime).IsRequired();
        builder.Property(delivery => delivery.DeliveryStatus).IsRequired(false);
        builder.Property(delivery => delivery.DeliveryDateTime).IsRequired(false);
    }
}
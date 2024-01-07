using Karami.Domain.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karami.Persistence.Configs.C;

public class TemplateConfig : IEntityTypeConfiguration<SmsQuery>
{
    public void Configure(EntityTypeBuilder<SmsQuery> builder)
    {
        //PrimaryKey
        
        builder.HasKey(Permission => Permission.Id);

        builder.ToTable("Permissions");
        
        /*-----------------------------------------------------------*/

        //Property

        /*-----------------------------------------------------------*/
        
        //Relations
    }
}
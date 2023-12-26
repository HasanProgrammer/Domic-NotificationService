using Karami.Domain.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karami.Persistence.Configs.Q;

public class TemplateQueryConfig : IEntityTypeConfiguration<TemplateQuery>
{
    public void Configure(EntityTypeBuilder<TemplateQuery> builder)
    {
        //PrimaryKey
        
        builder.HasKey(template => template.Id);

        builder.ToTable("Templates");
        
        /*-----------------------------------------------------------*/

        //Property

        /*-----------------------------------------------------------*/
        
        //Relations
    }
}
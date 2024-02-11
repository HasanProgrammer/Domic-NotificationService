using Domic.Core.Persistence.Configs;
using Domic.Domain.Service.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domic.Persistence.Configs.Q;

public class SmsQueryConfig : BaseEntityQueryConfig<SmsQuery, string>
{
    public override void Configure(EntityTypeBuilder<SmsQuery> builder)
    {
        base.Configure(builder);
        
        //PrimaryKey

        /*-----------------------------------------------------------*/

        //Property

        /*-----------------------------------------------------------*/
        
        //Relations
    }
}
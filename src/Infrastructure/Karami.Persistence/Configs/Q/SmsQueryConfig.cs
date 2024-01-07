using Karami.Core.Persistence.Configs;
using Karami.Domain.Service.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karami.Persistence.Configs.Q;

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
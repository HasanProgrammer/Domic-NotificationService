using Karami.Persistence.Contexts.Q;

namespace Karami.Infrastructure.Extensions.Q;

public static class SQLContextExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public static void Seed(this SQLContext context)
    {
        #region Template Seeder

        #endregion

        context.SaveChanges();
    }
}
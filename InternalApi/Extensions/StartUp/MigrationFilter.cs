
using Microsoft.EntityFrameworkCore;

namespace InternalApi.Extensions.StartUp;
public class MigrationFilter<TContext> : IStartupFilter where TContext : DbContext
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return app =>
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                foreach (var context in scope.ServiceProvider.GetServices<TContext>())
                {
                    if(context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.SetCommandTimeout(60);
                        context.Database.Migrate();
                    }
                }
            }
            next(app);
        };
    }
}
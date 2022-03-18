using LMSGrupp3.Data;

namespace LMSGrupp3.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

                try
                {
                    await SeedData.InitAsync(db);
                }
                catch (Exception ex)
                {
                    var logger = serviceProvider.GetService<ILogger<Program>>();
                    logger.LogError(string.Join("", ex.Message));
                }
            }

            return app;
        }
    }
}

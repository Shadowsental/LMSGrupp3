using LMSGrupp3.Data;
using LMSGrupp3.Models.Entities;
using Microsoft.AspNetCore.Identity;

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
                var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                try
                {
                    await SeedData.InitAsync(db, userManager, roleManager);
                }
                catch (Exception ex)
                {
                    throw;
                    var logger = serviceProvider.GetService<ILogger<Program>>();
                    logger.LogError(string.Join("", ex.Message));
                }
            }

            return app;
        }
    }
}

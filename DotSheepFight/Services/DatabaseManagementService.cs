using Microsoft.EntityFrameworkCore;

namespace DotSheepFight.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder application)
        {
            using var serviceScope = application.ApplicationServices.CreateScope();

            var serviceDb = serviceScope.ServiceProvider.GetService<DotSheepFightContext>();

            serviceDb.Database.Migrate();
        }
    }
}

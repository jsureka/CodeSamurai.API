using Microsoft.EntityFrameworkCore;

namespace CodeSamurai.API.Core
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<DBContext>())
                {
                    try
                    {
                        // Remove all records from each table
                        foreach (var entityType in appContext.Model.GetEntityTypes())
                        {
                            var tableName = entityType.GetTableName();
                            var sqlCommand = $"DELETE FROM {tableName}";
                            appContext.Database.ExecuteSqlRaw(sqlCommand);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }

            return host;
        }
    }
    }

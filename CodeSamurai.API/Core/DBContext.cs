using CodeSamurai.API.Entities;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Nest;

namespace CodeSamurai.API.Core
{
    public class DBContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;

        public DBContext(DbContextOptions<DBContext> options) : base(options) {
            try
            {
                var dbCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dbCreater != null)
                {
                    if (!dbCreater.CanConnect())
                    {
                        dbCreater.Create();
                    }
                    if (!dbCreater.HasTables())
                    {
                        dbCreater.CreateTables();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

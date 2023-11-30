using MicroserviceDemoWithDocker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace MicroserviceDemoWithDocker.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
            var DatabaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

            if (DatabaseCreator != null)
            {
                if (!DatabaseCreator.CanConnect())
                    DatabaseCreator.Create();
                if (!DatabaseCreator.HasTables())
                    DatabaseCreator.CreateTables();
            }
        }
        public DbSet<Person> People { get; set; }
    }
}

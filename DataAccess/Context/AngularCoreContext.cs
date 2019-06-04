using System.Runtime.CompilerServices;
using DataAccess.ModelConfigurations;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

[assembly: InternalsVisibleTo("DataAccess.Test")]
namespace DataAccess.Context
{
    public class AngularCoreContext : DbContext
    {
        internal DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
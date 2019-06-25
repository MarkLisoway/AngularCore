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

        internal DbSet<Blog> Blogs { get; set; }

        internal DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new BlogPostConfiguration());
        }

    }

}

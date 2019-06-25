using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ModelConfigurations
{

    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {

        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder
                .HasKey(u => u.Id);
            builder
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(255);
        }

    }

}

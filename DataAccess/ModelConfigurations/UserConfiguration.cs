using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ModelConfigurations
{

    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
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

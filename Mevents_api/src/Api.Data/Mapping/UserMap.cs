using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.CPF);

            builder.HasIndex(u => u.Email)
                .IsUnique();
            
            builder.HasIndex(u => u.CPF)
                .IsUnique();
                
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(u => u.CPF)
                .IsRequired()
                .HasMaxLength(11);
            
            builder.Property(u => u.Email)
                .HasMaxLength(100);
        }
    }
}
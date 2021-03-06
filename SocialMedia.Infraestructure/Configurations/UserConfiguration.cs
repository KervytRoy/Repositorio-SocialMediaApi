using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {       

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("UserId");

            builder.Property(e => e.UserIdentity)
                .HasColumnName("UserIdentity")                
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasColumnName("UserPassword")                
                .HasMaxLength(200)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Role)
               .HasColumnName("Role")
               .HasMaxLength(15)
               .IsRequired();
               

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);            

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            
        }
    }
}

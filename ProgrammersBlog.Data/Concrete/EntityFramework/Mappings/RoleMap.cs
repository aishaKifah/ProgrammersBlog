using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using programmersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Data.Concrete.EntityFramework.Mappings
{
    class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.id);
            builder.Property(r => r.id).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).IsRequired(true);
            builder.Property(r => r.Name).HasMaxLength(30);
            builder.Property(r => r.Description).IsRequired(true);
            builder.Property(r => r.Description).HasMaxLength(250);
            builder.Property(r=> r.createdByname).IsRequired(true);
            builder.Property(r=> r.modifiedByName).IsRequired(true);
            builder.Property(r=> r.createdDate).IsRequired(true);
            builder.Property(r=> r.createdByname).HasMaxLength(50);
            builder.Property(r=> r.modifiedByName).HasMaxLength(50);
            builder.Property(r=> r.modifiedDate).IsRequired(true);
            builder.Property(r=> r.isActive).IsRequired(true);
            builder.Property(r=> r.isDeleted).IsRequired(true);
            builder.Property(r=> r.note).HasMaxLength(500);
            builder.ToTable("Roles");
            builder.HasData(
                new Role
                {
                    id = 1,
                    Name = "Admin",
                    Description = "role has all control on system",
                    createdByname = "initial registeration",
                    isActive = true,
                    isDeleted = false,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    note = "Admin role"
                }
                ) ;

        }
    }
}

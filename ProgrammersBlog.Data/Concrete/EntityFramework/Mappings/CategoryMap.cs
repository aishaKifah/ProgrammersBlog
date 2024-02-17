using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    class CategoryMAp : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired(true);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.createdByname).IsRequired(true);
            builder.Property(c => c.modifiedByName).IsRequired(true);
            builder.Property(c => c.createdDate).IsRequired(true);
            builder.Property(c => c.createdByname).HasMaxLength(50);
            builder.Property(c => c.modifiedByName).HasMaxLength(50);
            builder.Property(c => c.modifiedDate).IsRequired(true);
            builder.Property(c => c.isActive).IsRequired(true);
            builder.Property(c => c.isDeleted).IsRequired(true);
            builder.Property(c => c.note).HasMaxLength(200);
            builder.HasData(
                new Category
                {
                    id = 1,
                    Name = "java",
                    Description = "java learning and developping ",
                    createdByname = "initial registeration",
                    isActive = true,
                    isDeleted = false,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    note = "toturials , news "


                },
                new Category
                {
                    id = 2,
                    Name = "python",
                    Description = "python learning and developping ",
                    createdByname = "initial registeration",
                    isActive = true,
                    isDeleted = false,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    note = "toturials , news "


                },
                new Category
                {
                    id = 3,
                    Name = "C#",
                    Description = "java learning and developping ",
                    createdByname = "initial registeration",
                    isActive = true,
                    isDeleted = false,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    note = "toturials , news "


                }

                );

        }
    }
}

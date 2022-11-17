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
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.id);
            builder.Property(u => u.id).ValueGeneratedOnAdd();
            builder.Property(u => u.firstName).IsRequired(true);
            builder.Property(u => u.lastName).IsRequired(true);
            builder.Property(u => u.email).IsRequired(true);
            builder.HasIndex(u => u.email).IsUnique();
            builder.Property(u => u.passwordHash).IsRequired(true);
            builder.Property(u => u.passwordHash).HasColumnType("VARBINARY(500)");
            builder.Property(u => u.userName).IsRequired(true);
            builder.HasIndex(u => u.userName).IsUnique();
            builder.Property(u => u.picture).IsRequired(true);
            builder.Property(u => u.firstName).HasMaxLength(100);
            builder.Property(u => u.lastName).HasMaxLength(100);
            builder.Property(u => u.email).HasMaxLength(50);
            builder.Property(u => u.userName).HasMaxLength(20);
            builder.Property(u=> u.createdByname).IsRequired(true);
            builder.Property(u=>u.modifiedByName).IsRequired(true);
            builder.Property(u=>u.createdDate).IsRequired(true);
            builder.Property(u=>u.createdByname).HasMaxLength(50);
            builder.Property(u=>u.modifiedByName).HasMaxLength(50);
            builder.Property(u=>u.modifiedDate).IsRequired(true);
            builder.Property(u=>u.isActive).IsRequired(true);
            builder.Property(u=>u.isDeleted).IsRequired(true);
            builder.Property(u=>u.note).HasMaxLength(500);
            builder.HasOne(u => u.role).WithMany(u=>u.users).HasForeignKey(u => u.roleId);
            builder.ToTable("Users");
            builder.HasData(
             new User
             {
                 id = 1,
                 firstName="Aycha",
                 lastName="Yahia",
                 email="aisha.kifah@gmail.com",
                 picture= "encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",
                 passwordHash=Encoding.ASCII.GetBytes("94fc91f73ebca8b8e134921cc59b12852471721988e815f70eee22b10e9fbc41"),
                 userName="aisha_kifah",
                 createdByname = "initial registeration",
                 isActive = true,
                 isDeleted = false,
                 createdDate = DateTime.Now,
                 modifiedDate = DateTime.Now,
                 note = "first user"
             }
             );
        }
    }
}

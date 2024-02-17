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
    class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.id).ValueGeneratedOnAdd();
            builder.Property(c => c.text).IsRequired(true);
            builder.Property(c => c.text).HasColumnType("NVARCHAR(MAX)");
            builder.Property(c => c.createdByname).IsRequired(true);
            builder.Property(c => c.modifiedByName).IsRequired(true);
            builder.Property(c => c.createdDate).IsRequired(true);
            builder.Property(c => c.createdByname).HasMaxLength(50);
            builder.Property(c => c.modifiedByName).HasMaxLength(50);
            builder.Property(c => c.modifiedDate).IsRequired(true);
            builder.Property(c => c.isActive).IsRequired(true);
            builder.Property(c => c.isDeleted).IsRequired(true);
            builder.Property(c => c.note).HasMaxLength(500);
            builder.ToTable("Comments");

        }
    }
}

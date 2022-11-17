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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a=> a.id);
            builder.Property(a => a.id).ValueGeneratedOnAdd();
            builder.Property(a => a.tilte).HasMaxLength(100);
            builder.Property(a => a.tilte).IsRequired(true);
            builder.Property(a => a.content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Date).IsRequired(true);
            builder.Property(a => a.viewsCount).IsRequired(true);
            builder.Property(a => a.commentsCount).IsRequired(true);
            builder.Property(a => a.seoDescreption).IsRequired(true);
            builder.Property(a => a.seoTags).IsRequired(true);
            builder.Property(a => a.seoAouther).IsRequired(true);
            builder.Property(a => a.seoAouther).HasMaxLength(40);
            builder.Property(a => a.thumbnail).IsRequired(true);
            builder.Property(a => a.thumbnail).HasMaxLength(250);
            builder.Property(a => a.seoDescreption).HasMaxLength(150);
            builder.Property(a => a.seoTags).HasMaxLength(70);
            builder.Property(a => a.createdByname).IsRequired(true);
            builder.Property(a => a.modifiedByName).IsRequired(true);
            builder.Property(a => a.createdDate).IsRequired(true);
            builder.Property(a => a.createdByname).HasMaxLength(50);
            builder.Property(a => a.modifiedByName).HasMaxLength(50);
            builder.Property(a => a.modifiedDate).IsRequired(true);
            builder.Property(a => a.isActive).IsRequired(true);
            builder.Property(a => a.isDeleted).IsRequired(true);
            builder.Property(a => a.note).HasMaxLength(500);
            builder.HasOne<Category>(a => a.category).WithMany(c => c.Articles).HasForeignKey(a => a.categoryId);
            builder.HasOne<User>(a => a.user).WithMany(u => u.articles).HasForeignKey(a => a.userID);
            builder.ToTable("Articles");
            builder.HasData(
                new Article { 
                    id=1,
                    tilte="What is java?",
                    content= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    viewsCount=100,
                    commentsCount=1,
                    seoDescreption="java oop objects java project ",
                    seoTags= "java oop objects java project",
                    createdByname = "initial registeration",
                    isActive = true,
                    isDeleted = false,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    note = "introduction to course",
                    categoryId=1,
                    userID=1,
                    thumbnail= "encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",
                    seoAouther="Aycha Yahia"

                },
                new Article
                {
                    id = 2,
                    tilte = "What is pyhton?",
                    content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    viewsCount = 100,
                    commentsCount = 1,
                    seoDescreption = "pyhton oop cnn  ML  project ",
                    seoTags = "java oop objects java project",
                    createdByname = "initial registeration",
                    isActive = true,
                    isDeleted = false,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    note = "introduction to course",
                    categoryId = 2,
                    userID = 1,
                    thumbnail = "encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",
                    seoAouther = "Aycha Yahia"

                },
                new Article
                {
                    id = 3,
                    tilte = "What is C#?",
                    content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    viewsCount = 100,
                    commentsCount = 1,
                    seoDescreption = ".NET .Net core oop visual Studio project ",
                    seoTags = "NET .Net core oop visual Studio project",
                    createdByname = "initial registeration",
                    isActive = true,
                    isDeleted = false,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    note = "introduction to course",
                    categoryId = 3,
                    userID = 1,
                    thumbnail = "encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",
                    seoAouther = "Aycha Yahia"

                }
                );




        }
    }
}

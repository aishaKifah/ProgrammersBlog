using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.id);
            builder.Property(a => a.id).ValueGeneratedOnAdd();
            builder.Property(a => a.title).HasMaxLength(100);
            builder.Property(a => a.title).IsRequired(true);
            builder.Property(a => a.content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Date).IsRequired(true);
            builder.Property(a => a.ViewsCount).IsRequired(true);
            builder.Property(a => a.CommentsCount).IsRequired(true);
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
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
            builder.HasOne<User>(a => a.user).WithMany(u => u.Articles).HasForeignKey(a => a.userID);
            builder.ToTable("Articles");
            //    builder.HasData(
            //        new Article { 
            //            id=1,
            //            title = "What is java?",
            //            content= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            //            ViewsCount=100,
            //            CommentsCount=1,
            //            seoDescreption="java oop objects java project ",
            //            seoTags= "java oop objects java project",
            //            createdByname = "initial registeration",
            //            isActive = true,
            //            isDeleted = false,
            //            createdDate = DateTime.Now,
            //            modifiedDate = DateTime.Now,
            //            note = "introduction to course",
            //            CategoryId=1,
            //            userID=1,
            //            thumbnail= "encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",
            //            seoAouther="Aycha Yahia"

            //        },
            //        new Article
            //        {
            //            id = 2,
            //            title = "What is pyhton?",
            //            content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            //            ViewsCount = 100,
            //            CommentsCount = 1,
            //            seoDescreption = "pyhton oop cnn  ML  project ",
            //            seoTags = "java oop objects java project",
            //            createdByname = "initial registeration",
            //            isActive = true,
            //            isDeleted = false,
            //            createdDate = DateTime.Now,
            //            modifiedDate = DateTime.Now,
            //            note = "introduction to course",
            //            CategoryId = 2,
            //            userID = 1,
            //            thumbnail = "encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",
            //            seoAouther = "Aycha Yahia"

            //        },
            //        new Article
            //        {
            //            id = 3,
            //            title = "What is C#?",
            //            content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            //            ViewsCount = 100,
            //            CommentsCount = 1,
            //            seoDescreption = ".NET .Net core oop visual Studio project ",
            //            seoTags = "NET .Net core oop visual Studio project",
            //            createdByname = "initial registeration",
            //            isActive = true,
            //            isDeleted = false,
            //            createdDate = DateTime.Now,
            //            modifiedDate = DateTime.Now,
            //            note = "introduction to course",
            //            CategoryId = 3,
            //            userID = 1,
            //            thumbnail = "encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",
            //            seoAouther = "Aycha Yahia"

            //        }
            //        );




        }
    }
}

using Microsoft.EntityFrameworkCore;
using programmersBlog.Data.Concrete.EntityFramework.Mappings;
using programmersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Data.Concrete.EntityFramework.Contexts
{
    public class ProgrammerBlogContext : DbContext
    {
        // db setleri hazirlama
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }

        // db ile baglanma hazirlama
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString : @"Server=localhost;Database=master;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CategoryMAp());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());

        }
    }
}
